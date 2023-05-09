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
        if (_navMeshAgent.isStopped)
        {
            _navMeshAgent.isStopped = false;
        }
        if (!_navMeshAgent.hasPath)
        {
            int random = Random.Range(0, _pathPoints.Length - 1);
            SetAgentDestination(_pathPoints[random].position);
        }
    }

    public void StopGoingToDestination()
    {
        _navMeshAgent.isStopped = true;
    }

    private void SetAgentDestination(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}

