using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectingSwitch : PowerNode
{
    protected override void Start()
    {
        base.Start();
    }


    protected override void OnOpen()
    {
        base.OnOpen();
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    protected override void OnClose()
    {
        base.OnClose();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
