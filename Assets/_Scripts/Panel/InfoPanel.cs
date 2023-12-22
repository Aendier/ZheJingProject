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
        nodeName.text = "选择节点："+ name;
        nodeSwitchState.text = "开关状态：" + (isSwitchOn ? "开" : "关");
        nodePowerfulState.text = "通电状态：" + (isPowerful ? "通电" : "断电");
    }
}
