using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{
    [SerializeField] private NavMeshController _navMeshController;
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private WeaponChange _weaponChange;
    [SerializeField] private FieldOfView _fieldOfView;

    private EnemyDetectionSystem _enemyDetectionSystem;
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
        _enemyDetectionSystem = new EnemyDetectionSystem(_fieldOfView);
        //_fieldOfView.OnEnemyDetect += OnAttackEnemyState;
    }


    private void Update()
    {
        switch (_currentState)
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
                {
                    Debug.Log("default");
                    _currentState = AIStates.Idle;
                    break;
                }
        }
    }

    private void OnIdleState()
    {
        if (_weaponController.HasAmmo())
        {
            _currentState = AIStates.SeekEnemy;
        }
    }

    private void OnSeekEnemyState()
    {
        _navMeshController.GoToRandomPoint();
        if (_enemyDetectionSystem.HasPlayer() && _weaponController.HasAmmo())
        {
            _currentState = AIStates.AttackEnemy;
        }
    }

    private void OnAttackEnemyState()
    {
        HumanStats enemy = _enemyDetectionSystem.GetLastSpottedEnemy();

        if (enemy == null)
        {
            _currentState = AIStates.SeekEnemy;
        }

        else if (!_weaponController.HasAmmo())
        {
            _weaponChange.SetCurrentWeaponFromInventory(_weaponChange.PreviousWeaponHolder);
            _currentState = AIStates.SeekEnemy;
        }
        _attackSystem.Attack(enemy);
    }
}
