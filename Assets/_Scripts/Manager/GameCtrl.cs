using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    PowerNodeCtrl nodeCtrl;
    PowerNodeSelector nodeSelector;

    // Start is called before the first frame update
    void Start()
    {
        nodeCtrl = GetComponent<PowerNodeCtrl>();
        nodeSelector = FindObjectOfType<PowerNodeSelector>();
        nodeCtrl.OnBtnClick += OnBtnClick;
        nodeCtrl.OffBtnClick += OffBtnClick;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnBtnClick()
    {
        if (nodeSelector.currentChoice != null)
            nodeSelector.currentChoice.IsOpen = true;
    }

    void OffBtnClick()
    {
        if (nodeSelector.currentChoice != null)
            nodeSelector.currentChoice.IsOpen = false;
    }
}
