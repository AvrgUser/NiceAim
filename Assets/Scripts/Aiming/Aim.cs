using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim
{
    public int importancy;
    public NPC self;
    public GameObject head;
    public GameObject body;

    public Aim(GameObject head, GameObject body, NPC self, int imp = 1)
    {
        (this.head, this.body, this.self, importancy) = (head, body, self, imp);
    }
}
