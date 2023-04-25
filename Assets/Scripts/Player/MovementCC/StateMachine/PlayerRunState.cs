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
        Ctx.CCAnimator.SetFloat(Ctx.HorizontalPatameterName, Ctx.HorizontalInput);
        Ctx.CCAnimator.SetFloat(Ctx.VerticalPatameterName, Ctx.VericalInput);

    }

    public override void UpdateState() 
    {
       
        //Ctx.move = Ctx.transform.right * Ctx.HorizontalInput + Ctx.transform.forward * Ctx.VericalInput;

        //Ctx.Controller.Move(Ctx.move * (Ctx.Speed * 2) * Time.deltaTime);  //??? 
        CheckSwitchStates();
    }

    public override void ExitState() 
    {

        //_ctx.Speed -= 100;

    }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (!Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Walk());
        }


    }
}
