using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{


    public PlayerIdleState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory) { }

    public override void EnterState() 
    {
        _ctx.Animator.SetBool(_ctx.IsWalkingHash, false);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, false);
    }

    public override void UpdateState() 
    {
        CheckSwitchStates();
    }

    public override void ExitState() { }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (_ctx.IsMovementPressent && _ctx.IsRunPressent)
        {
            SetSubState(_factory.Run());
        }
        else if(_ctx.IsMovementPressent)
        {
            SetSubState(_factory.Walk());
        }
    }
}
