using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerMovementState
{
    private PlayerMovement _playerMovement;
    private bool _jumped;
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (_playerMovement == null)
        {
            _playerMovement = playerMovement;
        }

        if (playerMovement.OnGround && _jumped)
        {
            _jumped = false;
            return playerMovement.IdleState;
        }
        else
        {
            Jump();
            return playerMovement.JumpState;
        }
    }
    private void Jump()
    {
        if (_playerMovement.OnGround)
        { 
            Ray ray = new Ray(_playerMovement.transform.position, -_playerMovement.transform.up);
            RaycastHit[] colliders = Physics.SphereCastAll(ray, 0.5f);
            {
                foreach (RaycastHit item in colliders)
                {
                    if (item.collider.gameObject.layer == _playerMovement.GroundLayer)
                    {
                        _playerMovement.OnGround = false;
                        //playerMovement.Rigidbody.AddForce(Time.fixedDeltaTime * playerMovement.JumpForce * Vector3.up, ForceMode.Impulse);
                        _playerMovement.Rigidbody.velocity += Time.fixedDeltaTime * _playerMovement.JumpForce * Vector3.up;
                        _jumped = true;
                    }
                }
            }
        }
    }
}
