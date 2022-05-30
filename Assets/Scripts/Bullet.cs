using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    public Vector2 screenPoint { get; private set; }

    public Bullet(Vector2 screenPoint)
    {
        this.screenPoint = screenPoint;
    }
}