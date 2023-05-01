//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FSMController : MonoBehaviour
//{
//    [SerializeField] private NavMeshController _navMeshController;
//    //[SerializeField] private DetectionSystem _detectionSystem;
//    [SerializeField] private WeaponController _weaponController;
//    [SerializeField] private WeaponChange _weaponChange;

//    private AIStates _currentState;

//    private enum AIStates
//    {
//        Idle,
//        SeekEnemy,
//        AttackEnemy,
//    }

//    private void UpdateState(AIStates state)
//    {
//        _currentState = state;
        
//        Debug.Log(_currentState);

//        switch (state)
//        {
//            case AIStates.Idle:
//                OnIdleState();
//                break;
//            case AIStates.SeekEnemy:
//                OnSeekEnemyState();
//                break;
//            case AIStates.AttackEnemy:
//                OnAttackEnemyState();
//                break;
//            default:
//                break;
//        }
//    }

//    private void OnIdleState()
//    {
//        if (_weaponController.HasAmmo)
//        {
//            UpdateState(AIStates.SeekEnemy);
//        }
//    }

//    private void OnWanderState()
//    {
        
//    }

//    private void OnSeekEnemyState()
//    {
//        if (_detectionSystem.HasPlayer && _weaponController.HasAmmo)
//        {
//            UpdateState(AIStates.AttackEnemy);
//        }
//    }

//    private void OnAttackEnemyState()
//    {
        
//        if (!_weaponController.HasAmmo)
//        {
//            _weaponChange.SetCurrentWeaponFromInventory(_weaponChange.PreviousWeaponHolder);
//        }
//        if (!_detectionSystem.HasPlayer)
//        {
//            UpdateState(AIStates.SeekEnemy);
//        }
//    }
//}
