using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    Text nodeName;
    Text nodeSwitchState;
    Text nodePowerfulState;
    void Start()
    {
        nodeName = transform.Find("NodeName").GetComponent<Text>();
        nodeSwitchState = transform.Find("NodeSwitchState").GetComponent<Text>();
        nodePowerfulState = transform.Find("NodePowerfulState").GetComponent<Text>();
    }

    public void SetInfo(string name, bool isPowerful, bool isSwitchOn)
    {
        nodeName.text = "ѡ��ڵ㣺"+ name;
        nodeSwitchState.text = "����״̬��" + (isSwitchOn ? "��" : "��");
        nodePowerfulState.text = "ͨ��״̬��" + (isPowerful ? "ͨ��" : "�ϵ�");
    }
}
