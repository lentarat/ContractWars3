using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{

    public PlayerJumpState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        _isRootState= true;
    }
    public override void EnterState() 
    {
        InitializeSubState();
         _ctx.CCAnimator.SetBool(_ctx.IsJumpingHash, true);
        //_ctx.CCAnimator.SetTrigger(_ctx.IsJumpingHashTrigger);
        Debug.Log("Jumping");
        HandleJump();
    }

    public override void UpdateState() 
    {
        CheckSwitchStates();

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
        if(_ctx.IsGrounded) 
        {
            SwitchState(_factory.Grounded());
        }
    }

    void HandleJump()
    {
        _ctx._velocity.y = Mathf.Sqrt(_ctx.JumpHeight * -2f * _ctx.Gravity);
        
    }

   

}
