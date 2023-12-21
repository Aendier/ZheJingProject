using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectingSwitch : PowerNode
{
    protected override void Start()
    {
        base.Start();
    }


    protected override void OnPower()
    {
        base.OnPower();
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    protected override void UnPower()
    {
        base.UnPower();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
