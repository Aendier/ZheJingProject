using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelCtrl : MonoBehaviour
{
    InfoPanel infoPanel;
    void Start()
    {
        infoPanel = FindObjectOfType<InfoPanel>();
    }

    public void SetCurrentNodeInfo(string name, bool isPowerful, bool isSwitchOn)
    {
        infoPanel.SetInfo(name, isPowerful, isSwitchOn);
    }
}

