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
        
        
        Debug.Log("Walk EnterState");


    }

    public override void UpdateState() 
    {
        Ctx.CCAnimator.SetFloat(Ctx.HorizontalPatameterName, Ctx.HorizontalInput);
        Ctx.CCAnimator.SetFloat(Ctx.VerticalPatameterName, Ctx.VericalInput);
        Debug.Log("Walk UpdateState");
        Ctx.move = (Ctx.gameObject.transform.right * Ctx.HorizontalInput) + (Ctx.gameObject.transform.forward * Ctx.VericalInput);
        Ctx.Controller.Move(Ctx.move * Ctx.Speed * Time.deltaTime);
        CheckSwitchStates();
        
    }

    public override void ExitState() 
    {
        

    }


    public override void InitializeSubState() { }

    public override void CheckSwitchStates() 
    {
        if (!Ctx.IsMovementPressed  )
        {
            SwitchState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {   
            SwitchState(Factory.Run());
        }
    }
}
