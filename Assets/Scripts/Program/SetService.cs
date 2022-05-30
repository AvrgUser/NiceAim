using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetService<T> where T : IService, new()
{
    public SetService()
    {
        T s = new T();
        s.Initialize();
    }
}
