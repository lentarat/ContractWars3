using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerMovementState
{
    private PlayerMovement _playerMovement;
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (_playerMovement == null)
        {
            _playerMovement = playerMovement;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return playerMovement.JumpState;
        }
        else if (playerMovement.InputVector != Vector3.zero)
        {
            return playerMovement.WalkState;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            return playerMovement.CrouchState;
        }
        else
        {
            Idle();
            return playerMovement.IdleState;
        }
    }
    private void Idle()
    {
    
    }
}
