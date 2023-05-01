using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _transformCube;

    public void SetAgentDestination()
    {
        float randomZ = Random.Range(-10, 100);
        float randomX = Random.Range(-10, 100);

        Vector3 walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        _navMeshAgent.SetDestination(walkPoint);
    }
}

