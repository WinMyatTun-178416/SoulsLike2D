using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FiniteStateMachine 
{
   public State currentState { get; private set; }
    public void Initailize(State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }
    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
