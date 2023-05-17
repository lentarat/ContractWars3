using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem
{
    private WeaponController _weaponController;
    private Transform _playerTransform;

    private float _aimingAccuracyMultiplier = 3f; 

    public AttackSystem(WeaponController weaponController, Transform playerTransform)
    {
        _weaponController = weaponController;
        _playerTransform = playerTransform;
    }

    public void Attack(HumanStats currentSpottedEnemy)
    {
        if (currentSpottedEnemy == null)
        {
            return;
        }

        FaceTarget(currentSpottedEnemy.transform);
        _weaponController.Shoot();
    }

    private void FaceTarget(Transform destination)
    {
        Vector3 lookPos = destination.position - _playerTransform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, rotation, Time.deltaTime * _aimingAccuracyMultiplier);
    }
}
