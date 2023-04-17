using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : IPlayerMovementState
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
        else if (!Input.GetKey(KeyCode.LeftControl))
        {
            if (CameraLerp(-_playerMovement.CrouchFrequency))
            {
                if (playerMovement.InputVector == Vector3.zero)
                {
                    return playerMovement.IdleState;
                }
                return playerMovement.WalkState;
            }
        }
        Crouch();
        return playerMovement.CrouchState;
    }
    private void Crouch()
    {
        if (_playerMovement.Rigidbody.velocity.magnitude > _playerMovement.MaxCrouchedSpeed)
        {
            _playerMovement.Rigidbody.velocity = _playerMovement.Rigidbody.velocity.normalized * _playerMovement.MaxCrouchedSpeed;
        }
        CameraLerp(_playerMovement.CrouchFrequency);
    }
    //return true if the camera is at maximum height;
    private bool CameraLerp(float crouchFrequency)
    {
        Debug.Log(_playerMovement.CameraLerpRatio);
        _playerMovement.CameraTransform.localPosition = Vector3.Lerp(_playerMovement.LerpCameraTo.localPosition, _playerMovement.LerpCameraFrom.localPosition, _playerMovement.CameraLerpRatio);

        if (_playerMovement.CameraLerpRatio > 1f)
        {
            _playerMovement.CameraLerpRatio = 1f;
            return true;
        }
        else if (_playerMovement.CameraLerpRatio < 0f)
        {
            _playerMovement.CameraLerpRatio = 0f;
        }
        else
        {
            _playerMovement.CameraLerpRatio += Time.deltaTime * crouchFrequency;
        }
        return false;
    }
}
