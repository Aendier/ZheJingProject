using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerNodeCtrl : MonoBehaviour
{
    public CtrlPanel ctrlPanel;
    public event Action OnBtnClick;
    public event Action OffBtnClick;
    void Start()
    {
        ctrlPanel = FindObjectOfType<CtrlPanel>();
        ctrlPanel.OnBtn.onClick.AddListener(() => { OnBtnClick?.Invoke(); });
        ctrlPanel.OffBtn.onClick.AddListener(() => { OffBtnClick?.Invoke(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
