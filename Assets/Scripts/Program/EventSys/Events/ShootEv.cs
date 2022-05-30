using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEv : DefEvent
{
    public ShootEv(GameObject shooter, Bullet bullet)
    {
        this.shooter = shooter;
        this.bullet = bullet;
    }

    public GameObject shooter { get; private set; }
    public Bullet bullet { get; private set; }
}