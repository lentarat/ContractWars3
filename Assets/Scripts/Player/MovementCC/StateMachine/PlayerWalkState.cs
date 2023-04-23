using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerCCStateMachine currentContext,PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState() 
    {

        /*_ctx.CCAnimator.SetBool("IsWalking", true);
        _ctx.CCAnimator.SetBool("IsRunning", false);*/
        /*_ctx.CCAnimator.SetBool(_ctx.IsWalkingHash, true);

        _ctx.CCAnimator.SetBool(_ctx.IsRunningHash, false);*/

        _ctx.CCAnimator.SetFloat(_ctx.HorizontalPatameterName, _ctx.HorizontalInput);
        _ctx.CCAnimator.SetFloat(_ctx.VerticalPatameterName, _ctx.VericalInput);
     
    }

    public override void UpdateState() 
    {

        //_ctx.move = _ctx.transform.right * _ctx.HorizontalInput + _ctx.transform.forward * _ctx.VericalInput;
        
        CheckSwitchStates();
        
    }

    public override void ExitState() { }


    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (!_ctx.IsMovementPressed  )
        {
            SwitchState(_factory.Idle());
        }
        else if (_ctx.IsMovementPressed && _ctx.IsRunPressed)
        {   
            SwitchState(_factory.Run());
        }
       
    }
}
