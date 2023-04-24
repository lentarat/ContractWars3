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
        /*_ctx.CCAnimator.SetBool(_ctx.IsWalkingHash, false);
        _ctx.CCAnimator.SetBool(_ctx.IsRunningHash, false);*/
        _ctx.CCAnimator.SetFloat(_ctx.HorizontalPatameterName, _ctx.HorizontalInput);
        _ctx.CCAnimator.SetFloat(_ctx.VerticalPatameterName, _ctx.VericalInput);

    }
    
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }

    public override void ExitState() {  }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (_ctx.IsMovementPressed && _ctx.IsRunPressed)
        {
            SwitchState(_factory.Run());
        }
        else if(_ctx.IsMovementPressed )
        {
            SwitchState(_factory.Walk());
        }

    }
}
