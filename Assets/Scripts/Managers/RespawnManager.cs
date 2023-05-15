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
    [SerializeField] private UIModeController _uiModeController;
    //[SerializeField] private GameObject _respawnPanel;

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
    }
    private void ShowRespawnPanel(bool state)
    {
        if (state == false)
        {
            _uiModeController.SetUIModeInactive(UIModeController.UIMode.Restart);
        }
        _uiModeController.ChangeUIMode(UIModeController.UIMode.Restart);
        //_respawnPanel.SetActive(state);
    }
}