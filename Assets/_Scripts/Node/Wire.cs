using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : Powerful
{
    public Powerful[] connectedObject;
    protected override void Start()
    {
        base.Start();
        IsPowerful = false;
        IsOpen = true;
    }

    public override void OnPower()
    {
        base.OnPower();
        if(connectedObject != null)
        {
            for (int i = 0; i < connectedObject.Length; i++)
            {
                if (connectedObject[i] != null && connectedObject[i].isOpen == true)
                {
                    connectedObject[i].OnPower();
                }
            }
        }
    }

    public override void UnPower()
    {
        base.UnPower();
        if (connectedObject != null)
        {
            for (int i = 0; i < connectedObject.Length; i++)
            {
                if (connectedObject[i] != null && connectedObject[i].isOpen == true)
                {
                    connectedObject[i].UnPower();
                }
            }
        }
    }
}

