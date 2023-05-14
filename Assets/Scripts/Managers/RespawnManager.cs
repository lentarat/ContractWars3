using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour
{
    private RespawnManager() { }

    private static RespawnManager _instance;
    public static RespawnManager Instance { get => _instance; private set => _instance = value; }

    [SerializeField] private PlayerListCreator _playerListCreator;
    [SerializeField] private GameObject _respawnPanel;

    [SerializeField] private float _initialTimeLeftToRespawn;
    public float TimeLeftToCloseUI { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void RespawnPlayer(HumanStats player, bool isPlayer)
    {
        //TimeLeftToRespawn = _initialTimeLeftToRespawn;
        StartCoroutine(RespawnCountdown(player, isPlayer, _initialTimeLeftToRespawn));
    }

    private IEnumerator RespawnCountdown(HumanStats playerToRespawn, bool isPlayer, float timeLeftToRespawn)
    {
        //TimeLeftToRespawn = _initialTimeLeftToRespawn;
        //SetDeathMode(true);

        //OnPlayerRespawn?.Invoke();

        if (isPlayer)
        {
            //UpdateRespawnPanel(false,Ti);
            ShowRespawnPanel(true);
        }

        while (timeLeftToRespawn > 0f)
        {
            timeLeftToRespawn -= Time.deltaTime;
            if (isPlayer)
            {
                TimeLeftToCloseUI = timeLeftToRespawn;
            }
            yield return null;
        }

        if (isPlayer)
        {
            if (playerToRespawn.TeamUnit == HumanStats.Unit.CounterTerrorist)
            {
                //OnCountdownElapsed?.Invoke(ChooseUnit.Unit.CounterTerrorist, true);
                _playerListCreator.SpawnHuman(ChooseUnit.Unit.CounterTerrorist, true);
            }
            else
            {
                _playerListCreator.SpawnHuman(ChooseUnit.Unit.Terrorist, true);
            }
            //UpdateRespawnPanel(false);
            ShowRespawnPanel(false);
        }
        else
        {
           if (playerToRespawn.TeamUnit == HumanStats.Unit.CounterTerrorist)
            {
                _playerListCreator.SpawnHuman(ChooseUnit.Unit.CounterTerrorist, false);
            }
            else
            {
                _playerListCreator.SpawnHuman(ChooseUnit.Unit.Terrorist, false);
            }
        }
        //if (player.TeamUnit == HumanStats.Unit.CounterTerrorist)
        //{
        //    OnCountdownElapsed?.Invoke(ChooseUnit.Unit.CounterTerrorist, false);
        //}
        //else
        //{
        //    OnCountdownElapsed?.Invoke(ChooseUnit.Unit.Terrorist, false);
        //}
        //PlayerList.Instance.Players.Add(playerToRespawn);
        //SetDeathMode(false);
    }

    ////private void UpdateRespawnPanel(bool state, float timeLeftToCloseUI)
    ////{
    ////    TimeLeftToCloseUI = timeLeftToCloseUI;
    ////    if (_respawnPanel.activeInHierarchy != state)
    ////    {
    ////        ShowRespawnPanel(state);
    ////        Debug.Log("showing");
    ////    }
    ////}

    private void ShowRespawnPanel(bool state)
    {
        _respawnPanel.SetActive(state);
    }
}

//public class WaitToRespawn
//{
//    private WaitToRespawn(float timeToRespawn)
//    {

//    }
//    public int Seconds;
//}
