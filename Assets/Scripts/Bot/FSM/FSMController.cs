using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{
    [SerializeField] private NavMeshController _navMeshController;
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private WeaponChange _weaponChange;
    [SerializeField] private FieldOfView _fieldOfView;

    private EnemyDetectionSystem _detectionSystem;
    private AttackSystem _attackSystem;

    private AIStates _currentState;

    private enum AIStates
    {
        Idle,
        SeekEnemy,
        AttackEnemy,
    }

    private void Awake()
    {
        _attackSystem = new AttackSystem(_weaponController, transform, _weaponController.CameraTransform);
        _detectionSystem = new EnemyDetectionSystem(_fieldOfView);
        _fieldOfView.OnEnemyDetect += OnAttackEnemyState;
    }

    private void Start()
    {
        UpdateState(AIStates.Idle);
    }

    private void Update()
    {
        //UpdateState(_currentState);
    }

    private void UpdateState(AIStates state)
    {
        _currentState = state;

        //Debug.Log(_currentState);

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
        if (_weaponController.HasAmmo())
        {
            UpdateState(AIStates.SeekEnemy);
        }
    }

    private void OnSeekEnemyState()
    {
        _navMeshController.GoToRandomPoint();
        if (_detectionSystem.HasPlayer() && _weaponController.HasAmmo())
        {
            UpdateState(AIStates.AttackEnemy);
        }
    }

    private void OnAttackEnemyState()
    {
        
        _attackSystem.Attack(_detectionSystem.CurrentSpottedPlayer);

        if (!_weaponController.HasAmmo())
        {
            _weaponChange.SetCurrentWeaponFromInventory(_weaponChange.PreviousWeaponHolder);
            UpdateState(AIStates.SeekEnemy);
        }
        if (!_detectionSystem.HasPlayer())
        {
            UpdateState(AIStates.SeekEnemy);
        }
        UpdateState(_currentState);
    }
}
