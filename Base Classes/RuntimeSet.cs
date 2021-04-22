using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public abstract class RuntimeSet<T> : ScriptableObject
{

    [ReorderableList]
    public List<T> items = new List<T>();

    public void Add(T t)
    {
        if (!items.Contains(t))
        {
            items.Add(t);
        }
    }

    public void Remove(T t)
    {
        if (items.Contains(t))
        {
            items.Remove(t);
        }
    }
}
