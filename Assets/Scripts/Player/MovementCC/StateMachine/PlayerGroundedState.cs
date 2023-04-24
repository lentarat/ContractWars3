using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{

    public PlayerGroundedState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        _isRootState= true;
    }

    public override void EnterState() 
    {
        InitializeSubState();
        _ctx.CCAnimator.SetBool(_ctx.IsJumpingHash, false);

    }

    public override void UpdateState() 
    {
        GravityHandler();
        CheckSwitchStates();
    }

    public override void ExitState() { }

    public override void InitializeSubState() 
    {
        if (!_ctx.IsMovementPressed && !_ctx.IsRunPressed)
        {
            SetSubState(_factory.Idle());
        }
        else if (_ctx.IsMovementPressed && !_ctx.IsRunPressed)
        {
            SetSubState(_factory.Walk());
        }
        else if (_ctx.IsMovementPressed && _ctx.IsRunPressed)
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
