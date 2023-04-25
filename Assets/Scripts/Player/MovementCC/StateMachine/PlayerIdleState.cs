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
        Ctx.CCAnimator.SetFloat(Ctx.HorizontalPatameterName, Ctx.HorizontalInput);
        Ctx.CCAnimator.SetFloat(Ctx.VerticalPatameterName, Ctx.VericalInput);

    }
    
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }

    public override void ExitState() {  }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SwitchState(Factory.Run());
        }
        else if(Ctx.IsMovementPressed )
        {
            SwitchState(Factory.Walk());
        }


    }
}
