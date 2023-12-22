using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    PowerNodeCtrl nodeCtrl;
    InfoPanelCtrl infoPanelCtrl;

    PowerNodeSelector nodeSelector;

    // Start is called before the first frame update
    void Start()
    {
        nodeCtrl = GetComponent<PowerNodeCtrl>();
        infoPanelCtrl = GetComponent<InfoPanelCtrl>();
        nodeSelector = FindObjectOfType<PowerNodeSelector>();
        nodeCtrl.OnBtnClick += OnBtnClick;
        nodeCtrl.OffBtnClick += OffBtnClick;
        nodeSelector.OnChoose += OnChoose;
    }

    void OnChoose()
    {
        infoPanelCtrl.SetCurrentNodeInfo(
            name: nodeSelector.currentChoice.gameObject.name,
                       isPowerful: nodeSelector.currentChoice.IsPowerful,
                                  isSwitchOn: nodeSelector.currentChoice.IsOpen);
    }

    void OnBtnClick()
    {
        if (nodeSelector.currentChoice != null)
        {
            nodeSelector.currentChoice.IsOpen = true;

            infoPanelCtrl.SetCurrentNodeInfo(
    name: nodeSelector.currentChoice.gameObject.name,
               isPowerful: nodeSelector.currentChoice.IsPowerful,
                          isSwitchOn: nodeSelector.currentChoice.IsOpen);
        }
    }

    void OffBtnClick()
    {
        if (nodeSelector.currentChoice != null)
        {
            nodeSelector.currentChoice.IsOpen = false;

            infoPanelCtrl.SetCurrentNodeInfo(
    name: nodeSelector.currentChoice.gameObject.name,
               isPowerful: nodeSelector.currentChoice.IsPowerful,
                          isSwitchOn: nodeSelector.currentChoice.IsOpen);
        }
    }
}
