using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class State
{
    [SerializeField]
    public string name;
    private List<StateMachineListener> listeners = new List<StateMachineListener>();

    public void Register(StateMachineListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegister(StateMachineListener listener)
    {
        listeners.Remove(listener);
    }

    public void OnEnter()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            if (listeners[i] != null)
            {
                try
                {
                    listeners[i].InvokeEnterResponse();
                }
                catch (Exception e)
                {
                    Debug.LogWarning("Caught While Entering State: " + e);
                }
            }
        }
    }

    public void OnExit()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            if (listeners[i] != null)
            {
                try
                {
                    listeners[i].InvokeExitResponse();
                }
                catch (Exception e)
                {
                    Debug.LogWarning("Caught While Exiting State: " + e);
                }
            }
        }
    }

    // override object.Equals
    public override bool Equals(object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            State state = (State)obj;
            return state.name == this.name;
        }
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
    }
}