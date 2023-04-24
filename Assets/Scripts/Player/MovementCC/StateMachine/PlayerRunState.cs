using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
   
    public PlayerRunState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState() 
    {
        //_ctx.Speed += 100;
        /*_ctx.CCAnimator.SetBool("IsWalking", true);
        _ctx.CCAnimator.SetBool("IsRunning", true);*/
       /* _ctx.CCAnimator.SetBool(_ctx.IsWalkingHash, true);
        _ctx.CCAnimator.SetBool(_ctx.IsRunningHash, true);*/
        _ctx.CCAnimator.SetFloat(_ctx.HorizontalPatameterName, _ctx.HorizontalInput);
        _ctx.CCAnimator.SetFloat(_ctx.VerticalPatameterName, _ctx.VericalInput);

    }

    public override void UpdateState() 
    {
        //_ctx.move = _ctx.transform.right * _ctx.HorizontalInput + _ctx.transform.forward * _ctx.VericalInput;

        //_ctx.Controller.Move(_ctx.move * (_ctx.Speed * 2) * Time.deltaTime);  //??? 
        CheckSwitchStates();
    }

    public override void ExitState() 
    {

        //_ctx.Speed -= 100;

    }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (!_ctx.IsMovementPressed)
        {
            SwitchState(_factory.Idle());
        }
        else if (_ctx.IsMovementPressed && !_ctx.IsRunPressed)
        {
            SwitchState(_factory.Walk());
        }
       

    }
}
