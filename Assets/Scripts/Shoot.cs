using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot
{
    public List<NPC> damaged = new List<NPC>();
    public Shoot(params NPC[] damaged)
    {
        foreach (NPC npc in damaged)
        {
            this.damaged.Add(npc);
        }
    }

    public Shoot(List<NPC> damaged)
    {
        this.damaged = damaged;
    }
}
