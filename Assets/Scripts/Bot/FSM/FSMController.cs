using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{
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
        
    }

    private void OnSeekEnemyState()
    {
    
    }

    private void OnAttackEnemyState()
    {
        
    }
}
