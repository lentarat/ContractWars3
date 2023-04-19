using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    public PlayerRunState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState() 
    {
        _ctx.Animator.SetBool(_ctx.IsWalkingHash, true);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, true);
        _ctx.Speed += 5;
    }

    public override void UpdateState() 
    {
        CheckSwitchStates();
    }

    public override void ExitState() { _ctx.Speed -= 5; }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (_ctx.IsMovementPressent && _ctx.IsRunPressent)
        {
            SetSubState(_factory.Run());
        }
        else if (_ctx.IsMovementPressent )
        {
            SetSubState(_factory.Walk());
        }
        
    }
}
