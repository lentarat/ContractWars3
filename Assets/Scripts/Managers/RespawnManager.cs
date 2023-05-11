using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private RespawnManager() { }

    private static RespawnManager _instance;
    public static RespawnManager Instance { get => _instance; private set => _instance = value; }

    [SerializeField] private float _timeToRespawn;

    public System.Action<ChooseUnit.Unit> OnCountdownElapsed;
    //private List<HumanStats> _playersToBeRespawned;

    private void Awake()
    {
        Instance = this;
    }

    public void RespawnPlayer (HumanStats player)
    {
        //_playersToBeRespawned.Add(player);
        if (player.CompareTag("Player"))
        {
            //UI
        }
        //new WaitToRespawn(_timeToRespawn);
        Respawn(player);
    }

    private void Respawn(HumanStats player)
    {
        StartCoroutine(RespawnCountdown(player, _timeToRespawn));
    }

    private IEnumerator RespawnCountdown(HumanStats player, float timeToRespawn)
    {
        //SetDeathMode(true);

        //OnPlayerRespawn?.Invoke();

        while (timeToRespawn > 0f)
        {
            timeToRespawn -= Time.deltaTime;
            yield return null;
        }
        timeToRespawn = 0f;

        if (player.TeamUnit == HumanStats.Unit.CounterTerrorist)
        {
            OnCountdownElapsed?.Invoke(ChooseUnit.Unit.CounterTerrorist);
        }
        else
        {
            OnCountdownElapsed?.Invoke(ChooseUnit.Unit.Terrorist);
        }

        //SetDeathMode(false);
    }


}

//public class WaitToRespawn
//{
//    private WaitToRespawn(float timeToRespawn)
//    {

//    }
//    public int Seconds;
//}
