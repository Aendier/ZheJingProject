using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNode : MonoBehaviour
{
    public MyNode next;
    public MyNode previous;
    public bool isHead;
    public bool isTail;

    public bool isOpen;
    //是否通电
    public bool onPower;

    public event Action OnNodeOpen;
    public event Action OnNodeClose;

    public Dynamo dynamo;

    public void Start()
    {
        if(dynamo != null)
        {
            
        }
    }
    public void OpenNode()
    {
        if (isOpen) return;

        isOpen = true;
        //检查上一个节点是否通电，如果通电，则当前节点通电
        CheckPreviousNode();
        //调用打开节点的事件
        OnNodeOpen?.Invoke();
    }

    public void CloseNode()
    {
        if (!isOpen) return;

        isOpen = false;
        CheckNextNode();
        OnNodeClose?.Invoke();
    }
        
    //判断之前的节点是否通电，通电则通电，并且调用下一个节点的通电方法
    private void CheckPreviousNode()
    {
        //如果上一个节点为空或者当前节点没有打开，则返回
        if (previous == null || isOpen == false) return;

        //如果上一个节点通电，则当前节点通电
        if (previous.onPower)
        {
            onPower = true;
            //调用下一个节点的通电方法
            previous.CheckPreviousNode();
        }
    }

    //在断电中调用，断电时，关闭当前节点，并且调用下一个节点的断电方法
    public void CheckNextNode()
    {
        //如果下一个节点为空或者当前节点没有打开，则返回
        if (next == null || isOpen == false) return;

        //如果下一个节点通电，则当前节点通电
        if (next.onPower)
        {
            next.onPower = false;
            //调用下一个节点的关电方法
            next.CheckNextNode();
        }
    }
}
