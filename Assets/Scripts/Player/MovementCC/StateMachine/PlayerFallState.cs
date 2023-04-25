using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
     : base(currentContext, playerStateFactory)
    {
        InitializeSubState();
        IsRootState = true;
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {

        GravityHandler();
        CheckSwitchStates();
    }

    public override void ExitState() { }

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
        if (Ctx.IsJumpPressed && !Ctx.RequireNewJumpPress)
        {
            SwitchState(Factory.Jump());
        }
        else if (Ctx.IsCrouchPressed)
        {
            SwitchState(Factory.Crouch());
        }


    }


    private void GravityHandler()
    {

        Ctx.IsGrounded = Physics.CheckSphere(Ctx.GroundCheck.position, Ctx.GroundDistance, Ctx.GroundMask);

        if (Ctx.IsGrounded && Ctx._velocity.y < 0)
        {
            Ctx._velocity.y = -2f;
        }

        Ctx._velocity.y += Ctx.Gravity * Time.deltaTime;
        Ctx.Controller.Move(Ctx._velocity * Time.deltaTime);
    }
}
