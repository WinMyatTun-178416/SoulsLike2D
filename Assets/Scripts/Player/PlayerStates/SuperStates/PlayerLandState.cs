using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
            if (xinput != 0f)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (isAnimationFisnished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
        
    }
}
