using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallUngrabState : PlayerTouchingWallState
{
    private Vector2 holdPositon;
    public PlayerWallUngrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        holdPositon = player.transform.position;
        HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        HoldPosition();
        if (!isExitingState)
        {
            if (yInput > 0)
            {
                stateMachine.ChangeState(player.wallClimbState);
            }
            else if (yInput < 0 || !grabInput)
            {
                stateMachine.ChangeState(player.wallSlideState);
            }
        }
        
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
   private  void HoldPosition()
    {
        player.transform.position = holdPositon;
        player.SetVelocityX(0f);
        player.SetVelocityY(0f);
    }
}
