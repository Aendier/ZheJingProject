using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Powerful : MonoBehaviour
{
    public Powerful previous;
    public Powerful next;

    public event Action OnPowerful;
    public event Action OnPowerless;

    protected Image image;

    //�Ƿ��
    public bool isOpen;
    //�Ƿ�ͨ��
    public bool isPowerful;

    public virtual bool IsOpen
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            if (isOpen)
                OnOpen();
            else
                OnClose();
        }
    }


    public virtual bool IsPowerful
    {
        get { return isPowerful; }
        set { isPowerful = value; }
    }


    protected virtual void Start()
    {
        isOpen = false;
        isPowerful = false;
        if (previous == null && next == null)
        {
            Debug.LogError("-----Useless Node-----");
        }
        image = GetComponent<Image>();

    }

    protected virtual void OnOpen()
    {
        CheckPreviousNode();
    }

    protected virtual void OnClose()
    {
        UnPower();
    }

    public virtual void OnPower()
    {
        Debug.Log(name + "OnPower");
        OnPowerful?.Invoke();
        image.color = Color.red;
        isPowerful = true;
        if (next != null && next.isOpen == true)
        {
            next.OnPower();
        }
    }

    public virtual void UnPower()
    {
        OnPowerless?.Invoke();
        image.color = Color.green;
        isPowerful = false;
        if (next != null)
        {
            next.UnPower();
        }
    }

    //�ڶϵ��е��ã��ϵ�ʱ���رյ�ǰ�ڵ㣬���ҵ�����һ���ڵ�Ķϵ緽��
    protected virtual void CheckNextNode()
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
    protected virtual void CheckPreviousNode()
    {
        //�����һ���ڵ�Ϊ�ջ��ߵ�ǰ�ڵ�û�д򿪣��򷵻�
        if (previous == null) return;

        //�����һ���ڵ��Ǵ򿪵Ĳ���ͨ�磬��ǰ�ڵ�ͨ��
        if (previous.isOpen && previous.isPowerful)
        {
            IsPowerful = true;
            OnPower();
        }
        else { IsPowerful = false;}
    }
}
