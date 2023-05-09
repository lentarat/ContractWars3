using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : MonoBehaviour
{
    [SerializeField] private HumanStats _humanStats;
    
    [SerializeField] private float _timeToRespawn;

    private void Start()
    {
        _humanStats.OnPlayerDeath += HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        StartCoroutine(RespawnCountDown(_timeToRespawn));    
    }

    private IEnumerator RespawnCountDown(float timeToRespawn)
    {
        yield return new WaitForSeconds(timeToRespawn);
    }
}
