using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IPlayerMovementState
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
        else if (playerMovement.InputVector == Vector3.zero)
        {
            return playerMovement.IdleState;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            return playerMovement.WalkState;
        }
        else
        {
            Run();
            return playerMovement.RunState;
        } 
    }
    private void Run()
    {
        if (_playerMovement.Rigidbody.velocity.magnitude > _playerMovement.MaxRunSpeed)
        {
            _playerMovement.Rigidbody.velocity = _playerMovement.Rigidbody.velocity.normalized * _playerMovement.MaxRunSpeed;
        }
    }
}
