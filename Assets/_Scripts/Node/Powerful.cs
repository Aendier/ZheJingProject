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

    //是否打开
    public bool isOpen;
    //是否通电
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

    //在断电中调用，断电时，关闭当前节点，并且调用下一个节点的断电方法
    protected virtual void CheckNextNode()
    {
        //如果下一个节点为空或者当前节点没有打开，则返回
        if (next == null) return;

        //如果下一个节点通电，则当前节点通电
        if (next.isPowerful)
        {
            next.isPowerful = false;
            //调用下一个节点的关电方法
            next.CheckNextNode();
        }
    }

    //判断之前的节点是否通电，通电则通电，并且调用下一个节点的通电方法
    protected virtual void CheckPreviousNode()
    {
        //如果上一个节点为空或者当前节点没有打开，则返回
        if (previous == null) return;

        //如果上一个节点是打开的并且通电，则当前节点通电
        if (previous.isOpen && previous.isPowerful)
        {
            IsPowerful = true;
            OnPower();
        }
        else { IsPowerful = false;}
    }
}
