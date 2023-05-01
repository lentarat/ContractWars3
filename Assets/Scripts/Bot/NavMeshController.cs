using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _pathPoints;

    public void GoToRandomPoint()
    {
        if (_navMeshAgent.hasPath) return;
        SetAgentDestination(_pathPoints[Random.Range(0, _pathPoints.Length)].position);
    }

    private void SetAgentDestination(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}

