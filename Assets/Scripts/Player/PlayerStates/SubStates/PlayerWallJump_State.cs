using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump_State : PlayerAbilityState
{
    public PlayerWallJump_State(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
}
