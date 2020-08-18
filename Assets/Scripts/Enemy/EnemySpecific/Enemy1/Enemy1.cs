using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleSate { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetecedState playerDetectedState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private Transform meleeAttackPosition;
    public override void Start()
    {
        base.Start();
       
        moveState = new E1_MoveState(this, stateMachine, "move",moveStateData,this);
        idleSate = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetecedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E1_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stateMachine.Initailize(moveState);
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
