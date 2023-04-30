using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AIStates
{
    Idle,
    WeaponSearch,
    EnemySearch,
    Attacking
}

public class SimpleFSM : MonoBehaviour
{
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private VitalitySystem _vitalitySystem;
    [SerializeField] private EnemyDetectSystem _enemyDetectSystem;
    [SerializeField] private AttackingSystem _attackingSystem;
    [SerializeField] private WeaponSystem _weaponSystem;

    [SerializeField] private MapHelper _mapHelper;

    private AIStates _currentState;

    private void UpdateState(AIStates state)
    {
        _currentState = state;
        switch (state)
        {
            case AIStates.Idle:
                OnIdleState();
                break;
            case AIStates.WeaponSearch:
                OnWeaponSearchState();
                break;
            case AIStates.EnemySearch:
                OnEnemySearchState();
                break;
            case AIStates.Attacking:
                OnAttackingState();
                break;
            default:
                break;
        }
    }

    private void OnIdleState()
    {
        if (_weaponSystem.HasWeapon && _weaponSystem.HasAmmo)
        {
            if (_enemyDetectSystem.HasEnemy)
            {
                UpdateState(AIStates.Attacking);
            }
            else
            {
                UpdateState(AIStates.EnemySearch);
            }
        }
        else
        {
            UpdateState(AIStates.WeaponSearch);
        }
    }

    private void OnWeaponSearchState()
    {
        if (_weaponSystem.HasWeapon && _weaponSystem.HasAmmo)
        {
            if (_enemyDetectSystem.HasEnemy)
            {
                UpdateState(AIStates.Attacking);
            }
            else
            {
                UpdateState(AIStates.EnemySearch);
            }
        }
        else
        {
            var weaponSearchPoint = _mapHelper.GetWeaponSearchRandomPoint();
            _movementSystem.MoveToPosition(weaponSearchPoint.position);
        }
    }

    private void OnEnemySearchState()
    {
        if (_enemyDetectSystem.HasEnemy)
        {
            UpdateState(AIStates.Attacking);
        }
        else
        {
            var enemySearchPoint = _mapHelper.GetEnemySearchRandomPoint();
            _movementSystem.MoveToPosition(enemySearchPoint.position);
        }
    }

    private void OnAttackingState()
    {
        if (_enemyDetectSystem.FindingEnemy.IsAlive)
        {
            _attackingSystem.Attack(_enemyDetectSystem.FindingEnemy);
        }
    }


    private void OnPositionReachedHandler()
    {
        if (_currentState == AIStates.WeaponSearch)
        {
            UpdateState(AIStates.WeaponSearch);
        }
        else if (_currentState == AIStates.EnemySearch)
        {
            UpdateState(AIStates.EnemySearch);
        }
    }

    private void OnEnemyDetecthandler(Enemy enemy)
    {
        if (_currentState == AIStates.EnemySearch)
        {
            UpdateState(AIStates.Attacking);
        }

    }

    private void OnWeaponTakeHandler()
    {
        if (_currentState == AIStates.WeaponSearch)
        {
            if (_weaponSystem.HasAmmo)
            {
                if (_enemyDetectSystem.HasEnemy)
                {
                    UpdateState(AIStates.Attacking);
                }
                else
                {
                    UpdateState(AIStates.EnemySearch);
                }
            }
            else
            {
                UpdateState(AIStates.WeaponSearch);
            }
        }
    }

    private void OnAmmoTakeHandler()
    {
        if (_currentState == AIStates.WeaponSearch)
        {
            //need to add check for same weapon and ammo
            if (_enemyDetectSystem.HasEnemy)
            {
                UpdateState(AIStates.Attacking);
            }
            else
            {
                UpdateState(AIStates.EnemySearch);
            }
        }

    }

    private void OnEnemyDeath(Enemy enemy)
    {
        if (_weaponSystem.HasWeapon && _weaponSystem.HasAmmo)
        {
            if (_enemyDetectSystem.FindingEnemy != enemy)
            {
                UpdateState(AIStates.Attacking);
            }
            else
            {
                UpdateState(AIStates.EnemySearch);
            }
        }
        else
        {
            UpdateState(AIStates.WeaponSearch);
        }
    }
}

public class MovementSystem : MonoBehaviour
{
    public bool IsInMovement { get; private set; }
    public Transform TargetMovement { get; private set; }
    public Vector3 TargetPosition { get; private set; }

    public event System.Action OnTargetReached;
    public event System.Action OnPositionReached;

    public void MoveToTarget(Transform target)
    {

    }

    public void MoveToPosition(Vector3 position)
    {

    }
}


public class WeaponSystem : MonoBehaviour
{
    public bool HasWeapon => _weapo is null == false;
    public bool HasAmmo => _weapo.BulletInCartridge > 0;

    public event System.Action OnTakeWeaponEvent;
    public event System.Action OnAmmoTakeEvent;

    [SerializeField] private Weapo _weapo;
}

public class VitalitySystem : MonoBehaviour
{
    public bool IsAlive => HealthPoint > 0;
    public int HealthPoint { get; private set; }

    public event System.Action OnDeadEvent;
}


public class AttackingSystem : MonoBehaviour
{
    public Enemy AttackTarget { get; private set; }
    public event System.Action<Enemy> EnemyDestroyed;
    public void Attack(Enemy enemy)
    {

    }
}


public class EnemyDetectSystem : MonoBehaviour
{
    public bool HasEnemy => FindingEnemy is null == false;
    public Enemy FindingEnemy { get; private set; }

    public event System.Action<Enemy> EnemySpied;
}

public class Enemy : VitalitySystem
{
}



public enum WeaponTyp
{
    Glock19,
    Ak_47,
    M4A,
    M16,

}
public class Weapo : MonoBehaviour
{
    [SerializeField] private WeaponTyp _type;
    public WeaponTyp Type => _type;
    public int BulletInCartridge { get; private set; }
}

public class MapHelper : MonoBehaviour
{
    [SerializeField] private List<Transform> _enemySearchPoints;
    [SerializeField] private List<Transform> _weaponSearchPoints;

    public Transform GetEnemySearchPointSequences()
    {
        return null;
    }

    public Transform GetEnemySearchRandomPoint()
    {
        return null;
    }

    public Transform GetWeaponSearchPointSequences()
    {
        return null;
    }

    public Transform GetWeaponSearchRandomPoint()
    {
        return null;
    }
}