using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class StateMachineListener : MonoBehaviour
{
    [Required]
    public StateMachine stateMachine;
    [Dropdown("GetAvailableStates"), ValidateInput("IsNotNull")]
    public State state;
    public UnityEvent enterResponse;
    public UnityEvent exitResponse;

    private void OnEnable()
    {
        stateMachine.FindState(state.name).Register(this);
        if (stateMachine.currentState.name == state.name)
        {
            InvokeEnterResponse();
        }
    }

    private void OnDisable()
    {
        stateMachine.FindState(state.name).DeRegister(this);
    }

    public void InvokeEnterResponse()
    {
        enterResponse.Invoke();
    }

    public void InvokeExitResponse()
    {
        exitResponse.Invoke();
    }

    private DropdownList<State> GetAvailableStates()
    {
        DropdownList<State> dropdownList = new DropdownList<State>();
        if (stateMachine != null)
        {
            foreach (State state in stateMachine.availableStates)
            {
                dropdownList.Add(state.name, state);
            }
        }
        return dropdownList;
    }

    private bool IsNotNull(State selectedState)
    {
        return selectedState != null;
    }
}