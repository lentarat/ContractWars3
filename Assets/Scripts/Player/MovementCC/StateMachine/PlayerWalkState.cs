using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerCCStateMachine currentContext,PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState() 
    {
        _ctx.Animator.SetBool(_ctx.IsWalkingHash, true);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, false);
    }

    public override void UpdateState() 
    {
        CheckSwitchStates();
        Vector3 move = _ctx.transform.right * _ctx.HorizontalInput + _ctx.transform.forward * _ctx.VericalInput;

        _ctx.Controller.Move(move * _ctx.Speed * Time.deltaTime);
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (!_ctx.IsMovementPressent )
        {
            SetSubState(_factory.Idle());
        }
        else if (_ctx.IsMovementPressent && _ctx.IsRunPressent)
        {
            SetSubState(_factory.Run());
        }
       
    }
}
