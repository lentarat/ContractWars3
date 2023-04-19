using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{

    public PlayerJumpState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        _isRootState= true;
        InitializeSubState();
    }
    public override void EnterState() 
    {
        HandleJump();
    }

    public override void UpdateState() 
    {
        CheckSwitchStates();
        GravityHandler();

    }

    public override void ExitState() 
    {
        if(_ctx.IsJumpPressed) 
        { 
            _ctx.RequireNewJumpPress = true; 
        }
        
        
    }

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
        if(_ctx.IsGrounded) 
        {
            SwitchState(_factory.Grounded());
        }
    }

    void HandleJump()
    {
        _ctx._velocity.y = Mathf.Sqrt(_ctx.JumpHeight * -2f * _ctx.Gravity);
        
    }

    private void GravityHandler()
    {

        _ctx.IsGrounded = Physics.CheckSphere(_ctx.GroundCheck.position, _ctx.GroundDistance, _ctx.GroundMask);

        if (_ctx.IsGrounded && _ctx._velocity.y < 0)
        {
            _ctx._velocity.y = -2f;
        }
        _ctx._velocity.y += _ctx.Gravity * Time.deltaTime;


        _ctx.Controller.Move(_ctx._velocity * Time.deltaTime);
    }

}
