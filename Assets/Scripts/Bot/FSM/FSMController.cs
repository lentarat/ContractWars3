using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{
    [SerializeField] private NavMeshController _navMeshController;
    //[SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] private WeaponController _weaponController;

    private AIStates _currentState;

    private enum AIStates
    {
        Idle,
        SeekEnemy,
        AttackEnemy
    }

    private void UpdateState(AIStates state)
    {
        _currentState = state;
        
        Debug.Log(_currentState);

        switch (state)
        {
            case AIStates.Idle:
                OnIdleState();
                break;
            case AIStates.SeekEnemy:
                OnSeekEnemyState();
                break;
            case AIStates.AttackEnemy:
                OnAttackEnemyState();
                break;
            default:
                break;
        }
    }

    private void OnIdleState()
    {
    //    if (_detectionSystem.HasPlayer && _weaponController.HasAmmo)
    //    {
    //        UpdateState(AIStates.SeekEnemy);
    //    }
    }

    private void OnSeekEnemyState()
    {

    }

    private void OnAttackEnemyState()
    {

    }
}
