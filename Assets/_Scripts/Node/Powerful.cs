using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Powerful : MonoBehaviour
{
    public Powerful next;
    public Powerful previous;

    public event Action OnPowerful;
    public event Action OnPowerless;


    private Image image;
    //�Ƿ�ͨ��
    private bool isPowerful;
    private bool isOpen;

    public virtual bool IsPowerful
    {
        get { return isPowerful; }
        set
        {
            isPowerful = value;
            if (isPowerful)
            {
                OnPower();
            }
            else
            {
                UnPower();
            }
        }
    }

    public virtual bool IsOpen
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            if (isOpen)
            {
                Debug.Log(name + "��ͨ����");
                CheckPreviousNode();
            }
            else
            {
                Debug.Log(name + "�Ͽ���");
                UnPower();
            }
        }
    }
    protected virtual void Start()
    {
        if(previous ==null && next == null)
        {
            Debug.LogError("-----Useless Node-----");
        }
        image = GetComponent<Image>();
        
    }

    protected virtual void OnPower()
    {
        OnPowerful?.Invoke();
        image.color = Color.red;
        isPowerful = true;
        if(next != null && next.isOpen == true)
        {
            next.IsPowerful = true;
        }
    }

    protected virtual void UnPower()
    {
        OnPowerless?.Invoke();
        image.color = Color.green;
        isPowerful = false;
        if(next != null)
        {
            next.IsPowerful = false;
        }
    }

    //�ڶϵ��е��ã��ϵ�ʱ���رյ�ǰ�ڵ㣬���ҵ�����һ���ڵ�Ķϵ緽��
    protected void CheckNextNode()
    {
        //�����һ���ڵ�Ϊ�ջ��ߵ�ǰ�ڵ�û�д򿪣��򷵻�
        if (next == null) return;

        //�����һ���ڵ�ͨ�磬��ǰ�ڵ�ͨ��
        if (next.isPowerful)
        {
            next.isPowerful = false;
            //������һ���ڵ�Ĺص緽��
            next.CheckNextNode();
        }
    }

    //�ж�֮ǰ�Ľڵ��Ƿ�ͨ�磬ͨ����ͨ�磬���ҵ�����һ���ڵ��ͨ�緽��
    protected void CheckPreviousNode()
    {
        //�����һ���ڵ�Ϊ�ջ��ߵ�ǰ�ڵ�û�д򿪣��򷵻�
        if (previous == null) return;

        //�����һ���ڵ��Ǵ򿪵Ĳ���ͨ�磬��ǰ�ڵ�ͨ��
        if (previous.isPowerful)
        {
            IsPowerful = true;
            //������һ���ڵ��ͨ�緽��
            previous.CheckNextNode();
        }
    }
}
