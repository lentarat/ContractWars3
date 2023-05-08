using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _pathPoints;
    private bool _wasHere;
    public void GoToRandomPoint()
    {
        if (!_wasHere)
        {
            _wasHere = true;
            if (_navMeshAgent.hasPath) return;
            int random = Random.Range(0, _pathPoints.Length - 1);
            SetAgentDestination(_pathPoints[random].position);
        }
    }

    private void SetAgentDestination(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}

