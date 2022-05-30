using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEv : DefEvent
{
    public NPC died;

    public DeathEv(NPC died)
    {
        this.died = died;
    }
}
