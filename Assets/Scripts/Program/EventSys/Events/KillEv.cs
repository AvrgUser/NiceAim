using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEv : DefEvent
{
    public Shoot shoot;

    public KillEv(Shoot shoot)
    {
        this.shoot = shoot;
    }
}
