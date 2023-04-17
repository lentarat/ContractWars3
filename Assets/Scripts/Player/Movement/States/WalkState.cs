using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IPlayerMovementState
{
    private PlayerMovement _playerMovement;
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (_playerMovement == null)
        {
            Debug.Log("test " + Time.time);
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
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            return playerMovement.RunState;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            return playerMovement.CrouchState;
        }
        else
        {
            Walk();
            return playerMovement.WalkState;
        }
    }
    private void Walk()
    {
        if(_playerMovement.Rigidbody.velocity.magnitude > _playerMovement.MaxWalkSpeed)
        {
            _playerMovement.Rigidbody.velocity = _playerMovement.Rigidbody.velocity.normalized * _playerMovement.MaxWalkSpeed;
        }
    }
    private void CameraLerp()    ////////  зробити пародію на еффект стаміни
    {
        Debug.Log(_playerMovement.CameraLerpRatio);
        _playerMovement.CameraTransform.localPosition = Vector3.Lerp(_playerMovement.LerpCameraFrom.localPosition, _playerMovement.LerpCameraTo.localPosition, _playerMovement.CameraLerpRatio += Time.deltaTime);
    }
}
