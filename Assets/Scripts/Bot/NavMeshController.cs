using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _transform;
    private void Update()
    {
        SetAgentDestination(_transform.position); 
    }
    public void SetAgentDestination(Vector3 position) 
    {
        _navMeshAgent.SetDestination(position);
    }
}
