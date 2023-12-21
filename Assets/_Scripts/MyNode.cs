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
    //�Ƿ�ͨ��
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
        //�����һ���ڵ��Ƿ�ͨ�磬���ͨ�磬��ǰ�ڵ�ͨ��
        CheckPreviousNode();
        //���ô򿪽ڵ���¼�
        OnNodeOpen?.Invoke();
    }

    public void CloseNode()
    {
        if (!isOpen) return;

        isOpen = false;
        CheckNextNode();
        OnNodeClose?.Invoke();
    }
        
    //�ж�֮ǰ�Ľڵ��Ƿ�ͨ�磬ͨ����ͨ�磬���ҵ�����һ���ڵ��ͨ�緽��
    private void CheckPreviousNode()
    {
        //�����һ���ڵ�Ϊ�ջ��ߵ�ǰ�ڵ�û�д򿪣��򷵻�
        if (previous == null || isOpen == false) return;

        //�����һ���ڵ�ͨ�磬��ǰ�ڵ�ͨ��
        if (previous.onPower)
        {
            onPower = true;
            //������һ���ڵ��ͨ�緽��
            previous.CheckPreviousNode();
        }
    }

    //�ڶϵ��е��ã��ϵ�ʱ���رյ�ǰ�ڵ㣬���ҵ�����һ���ڵ�Ķϵ緽��
    public void CheckNextNode()
    {
        //�����һ���ڵ�Ϊ�ջ��ߵ�ǰ�ڵ�û�д򿪣��򷵻�
        if (next == null || isOpen == false) return;

        //�����һ���ڵ�ͨ�磬��ǰ�ڵ�ͨ��
        if (next.onPower)
        {
            next.onPower = false;
            //������һ���ڵ�Ĺص緽��
            next.CheckNextNode();
        }
    }
}
