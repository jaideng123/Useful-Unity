using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StateMachine", order = 1)]
public class StateMachine : ScriptableObject
{
    [ValidateInput("AllStatesUnique")]
    public List<State> availableStates = new List<State>();
    [Dropdown("GetAvailableStates")]
    public State initialState;
    [ReadOnly]
    public State currentState;

    private void OnEnable()
    {
        currentState = null;
        ResetStateMachine();
    }

    public void ResetStateMachine()
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = initialState;
        currentState.OnEnter();
    }

    public void ChangeState(State nextState)
    {
        if (nextState == null)
        {
            Debug.LogError("Next State is Null");
            Debug.Break();
            return;
        }
        currentState.OnExit();
        currentState = nextState;
        nextState.OnEnter();
    }

    public void ChangeState(string nextStateName)
    {
        ChangeState(FindState(nextStateName));
    }

    public State FindState(string stateName)
    {
        State foundState = availableStates.Find((state) => state.name == stateName);
        if (foundState == null)
        {
            Debug.LogError("Found State is Null");
            Debug.Break();
        }
        return foundState;
    }

    private DropdownList<State> GetAvailableStates()
    {
        DropdownList<State> dropdownList = new DropdownList<State>();
        foreach (State state in availableStates)
        {
            dropdownList.Add(state.name, state);
        }
        return dropdownList;
    }

    private bool AllStatesUnique(List<State> states)
    {
        HashSet<string> usedNames = new HashSet<string>();
        foreach (State state in states)
        {
            if (usedNames.Contains(state.name))
            {
                return false;
            }
            usedNames.Add(state.name);
        }
        return true;
    }
}