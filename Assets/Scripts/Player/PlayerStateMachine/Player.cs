using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    [SerializeField]
    private PlayerData playerData;

    public PlayerJumpState JumpState { get; private set; }

    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerTouchingWallState touchingWallState { get; private set; }
    public PlayerWallUngrabState wallGrabState { get; private set; } 
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallClimbState wallClimbState { get; private set; }
    public PlayerWallJump_State WallJumpState { get; private set; }
    #endregion
    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Player_InputHandler InputHandler { get; private set; }
    #endregion
    #region Other Variables
    private Vector2 workspace;

    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }


    #endregion
    #region Check Transform
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;
    #endregion
    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this,StateMachine, playerData,"idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        wallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        wallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
        wallGrabState = new PlayerWallUngrabState(this, StateMachine, playerData, "wallGrab");
        WallJumpState = new PlayerWallJump_State(this,State);
    }

    private void Start()
    {
        FacingDirection = 1;
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<Player_InputHandler>();
        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        CurrentVelocity = RB.velocity;
        Anim.SetFloat("ajustment", CurrentVelocity.x / 10f);
        StateMachine.CurrentState.LogicUpdate();
       
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
    #region Set Functions
    
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    
 
    #endregion
    #region Check Functions
    public void CheckIfShouldFlip(int xinput)
    {
        if(xinput!=0 && xinput != FacingDirection)
        {
            Flip();
        }
    }
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatisGround);
    }
    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatisGround);
    }
    #endregion
    #region Other Functions
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
