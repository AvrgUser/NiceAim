using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InstancesManager
{
    static Dictionary<Type, object> instances = new Dictionary<Type, object>();

    public static void RegisterInstance(object instance)
    {
        Type type = instance.GetType();
        if (instances.ContainsKey(type))
        {
            instances[type] = instance;
        }
        else
        {
            instances.Add(type, instance);
        }
    }

    public static T GetInstance<T>()
    {
        if (instances.ContainsKey(typeof(T))) return (T)instances[typeof(T)];
        return default(T);
    }
}
