using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{

    public PlayerJumpState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        InitializeSubState();
        IsRootState= true;
    }
    public override void EnterState() 
    {
        Ctx.CCAnimator.SetBool(Ctx.IsJumpingHash, true);

        //_ctx.CCAnimator.SetTrigger(_ctx.IsJumpingHashTrigger);
        Debug.Log("Jumping");
        
    }

    public override void UpdateState() 
    {
       // Ctx.Controller.Move(Ctx.move * Ctx.Speed * Time.deltaTime);
        CheckSwitchStates();
        HandleJump();
    }

    public override void ExitState() 
    {
        if(Ctx.IsJumpPressed) 
        { 
        Ctx.RequireNewJumpPress = true; 
            
        }
        Ctx.CCAnimator.SetBool(Ctx.IsJumpingHash, false);
        Ctx.IsJoystickPressed= false;

    }

    public override void InitializeSubState() 
    {
        if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Walk());
        }
        else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SetSubState(Factory.Run());
        }

    }

    public override void CheckSwitchStates()
    {
        if(Ctx.IsGrounded) 
        {
            SwitchState(Factory.Grounded());
        }
      /*  else if (!Ctx.Controller.isGrounded)
        {
            SwitchState(Factory.Fall());
        }*/
        else if (Ctx.IsCrouchPressed )
        {
            SwitchState(Factory.Crouch());
        }
    }

    void HandleJump()
    {
        Ctx._velocity.y = Mathf.Sqrt(Ctx.JumpHeight * -2f * Ctx.Gravity);
        
    }

   

}
