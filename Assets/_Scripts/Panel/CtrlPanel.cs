using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlPanel : MonoBehaviour
{
   // [HideInInspector]
    public Button OnBtn;
    //[HideInInspector]
    public Button OffBtn;
   // [HideInInspector]
    public Button ExitBtn;

    // Start is called before the first frame update
    void Awake()
    {
        OnBtn = transform.Find("OnBtn").GetComponent<Button>();
        OffBtn = transform.Find("OffBtn").GetComponent<Button>();
        ExitBtn = transform.Find("ExitBtn").GetComponent<Button>();
        ExitBtn.onClick.AddListener(Application.Quit);
    }
}
