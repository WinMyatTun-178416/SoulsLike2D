using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;
    private bool jumpInput;
    private bool coyotrTime;
    private bool isJumping;
    private bool jumpInputStop;
    private bool isTouchingWall;
    private bool grabInput;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckCoyoteTime();
        grabInput = player.InputHandler.GrabInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        xInput = player.InputHandler.NormalizedInputX;
        jumpInput = player.InputHandler.JumpInput;
        CheckJumpMultiplier();
        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if(jumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if(isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.wallGrabState);
        }
        else if (isTouchingWall && xInput==player.FacingDirection)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);
            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity",Mathf.Abs(player.CurrentVelocity.x));
        }
    }
    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.CurrentVelocity.y <= 0)
            {
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    private void CheckCoyoteTime()
    {
        if(coyotrTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyotrTime = false;
            player.JumpState.DecreaseAmountOfJumpLeft();
        }
    }
    public void StartCoyoteTime()
    {
        coyotrTime = true;
    }
    public void SetIsJumping()
    {
        isJumping = true;
    }
}
