using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_State : State
{
    protected Transform attackPosition;
    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;
    public Attack_State(Entity entity, FiniteStateMachine stateMachine, string animBoolName,Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;
        entity.atsm.attackState = this;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhyisicsUpdate()
    {
        base.PhyisicsUpdate();
    }
    public virtual void TriggerAttack()
    {

    }
    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
