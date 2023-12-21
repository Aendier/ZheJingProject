using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{
    public PowerNode Powerful { get ; set; }

    private Outline outLine;
    void Start()
    {
        this.tag = "Selectable";
        Powerful = GetComponent<PowerNode>();
        outLine = this.AddComponent<Outline>();
        outLine.effectColor = Color.blue;
        outLine.effectDistance = new Vector2(5, 5);
        outLine.enabled = false;
    }

    public void Oncheck()
    {
        outLine.enabled = true;
    }

    public void Uncheck()
    {
        outLine.enabled = false;
    }
}
