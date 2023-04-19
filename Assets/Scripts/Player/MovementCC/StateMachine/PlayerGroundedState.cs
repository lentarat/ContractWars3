using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{

    public PlayerGroundedState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        _isRootState= true;
        InitializeSubState();
    }

    public override void EnterState() 
    {
        if (_ctx.IsGrounded && _ctx._velocity.y < 0)
        {
            _ctx._velocity.y = -2f;
        }
        _ctx._velocity.y += _ctx.Gravity * Time.deltaTime;


        _ctx.Controller.Move(_ctx._velocity * Time.deltaTime);
    }

    public override void UpdateState() 
    {
        CheckSwitchStates();
        
    }

    public override void ExitState() { }

    public override void InitializeSubState() 
    {
        if (!_ctx.IsMovementPressent && !_ctx.IsRunPressent)
        {
            SetSubState(_factory.Idle());
        }
        else if (_ctx.IsMovementPressent && !_ctx.IsRunPressent)
        {
            SetSubState(_factory.Walk());
        }
        else
        {
            SetSubState(_factory.Run());
        }
    }

    public override void CheckSwitchStates() 
    {
        if(_ctx.IsJumpPressed && !_ctx.RequireNewJumpPress) 
        {
            SwitchState(_factory.Jump());
        }
    }

}
