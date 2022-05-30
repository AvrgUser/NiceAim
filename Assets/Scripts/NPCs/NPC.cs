using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NPC
{
    public Aim GetAim();
    public void Act();
    public void GetKilled();
}
