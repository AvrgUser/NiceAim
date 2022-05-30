using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootsCache
{
    public ShootsCache()
    {
        InstancesManager.RegisterInstance(this);
    }

    public Dictionary<GameObject, Shoot> Shoots = new Dictionary<GameObject, Shoot>();
}
