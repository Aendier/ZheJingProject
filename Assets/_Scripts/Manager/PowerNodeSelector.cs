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
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            // 通过事件系统获取点击信息
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            // 获取点击的UI元素数组
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            // 处理点击到的UI元素
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    //Debug.Log("检测到了：" + results[i].gameObject.name);
                    if (results[i].gameObject.tag.Equals("Selectable"))
                    {
                        if(currentChoice != null)
                            currentChoice.gameObject.GetComponent<Selectable>().Uncheck();
                        currentChoice = results[i].gameObject.GetComponent<Selectable>().Powerful;
                        currentChoice.gameObject.GetComponent<Selectable>().Oncheck();
                        OnChoose?.Invoke();
                        Debug.Log("选中了：" + currentChoice.gameObject.name);
                        break;
                    }
                }
                // 在这里可以添加处理点击UI元素的逻辑
            }
        }
    }
}
