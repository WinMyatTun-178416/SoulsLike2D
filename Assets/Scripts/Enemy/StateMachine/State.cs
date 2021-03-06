using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    protected string animBoolName;
    protected float startTime;
    public State (Entity entity, FiniteStateMachine stateMachine,string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        startTime = Time.time;
        entity.Anim.SetBool(animBoolName, true);
        DoChecks();
    }
    public virtual void Exit()
    {
        entity.Anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhyisicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {

    }
}
