using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamo : PowerNode
{
    protected override void Start()
    {
        base.Start();
        IsOpen = true;
        OnPower();
    }

    protected override void CheckPreviousNode()
    {
        OnPower();
    }
}
