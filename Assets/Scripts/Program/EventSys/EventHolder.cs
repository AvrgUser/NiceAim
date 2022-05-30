using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventHolder
{
    static Dictionary<Type, UnityEvent<DefEvent>> dependencies = new Dictionary<Type, UnityEvent<DefEvent>>();

    static public void AddListener<T>(UnityAction<T> action) where T : DefEvent
    {
        bool found=false;
        foreach(Type e in dependencies.Keys)
        {
            if (e == typeof(T))
            {
                found = true;
                dependencies[e].AddListener((DefEvent a) => { action.Invoke((T)a); });
            }
        }
        if (!found)
        {
            dependencies.Add(typeof(T), new UnityEvent<DefEvent>());
            dependencies[typeof(T)].AddListener((DefEvent a) => { action.Invoke((T)a); });
        }
    }

    static public void Awake(DefEvent e)
    {
        dependencies[e.GetType()].Invoke(e);
    }
}