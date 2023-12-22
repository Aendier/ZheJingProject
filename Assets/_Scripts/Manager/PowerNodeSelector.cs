using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerNodeSelector : MonoBehaviour
{
    public PowerNode currentChoice;

    public event Action OnChoose;
    void Update()
    {
        // ��������
        if (Input.GetMouseButtonDown(0))
        {
            // ͨ���¼�ϵͳ��ȡ�����Ϣ
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            // ��ȡ�����UIԪ������
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            // ����������UIԪ��
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    //Debug.Log("��⵽�ˣ�" + results[i].gameObject.name);
                    if (results[i].gameObject.tag.Equals("Selectable"))
                    {
                        if(currentChoice != null)
                            currentChoice.gameObject.GetComponent<Selectable>().Uncheck();
                        currentChoice = results[i].gameObject.GetComponent<Selectable>().Powerful;
                        currentChoice.gameObject.GetComponent<Selectable>().Oncheck();
                        OnChoose?.Invoke();
                        Debug.Log("ѡ���ˣ�" + currentChoice.gameObject.name);
                        break;
                    }
                }
                // �����������Ӵ�����UIԪ�ص��߼�
            }
        }
    }
}
