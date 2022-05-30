using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTookOutEv : DefEvent
{
    public Aim enemy;
    public EnemyTookOutEv(Aim aim)
    {
        enemy = aim;
    }

    public EnemyTookOutEv(GameObject head, GameObject body, NPC self, int importancy)
    {
        enemy = new Aim(head, body, self, importancy);
    }
}
