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

    [SerializeField] private float _initialTimeLeftToRespawn;

    public System.Action OnPlayerRespawned;

    public float TimeLeftToCloseUI { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void RespawnHuman(HumanStats player, bool isPlayer)
    {
        StartCoroutine(RespawnCountdown(player, isPlayer, _initialTimeLeftToRespawn));
    }

    private IEnumerator RespawnCountdown(HumanStats playerToRespawn, bool isPlayer, float timeLeftToRespawn)
    {
        if (isPlayer)
        {
            ShowRespawnPanel(true);
        }

        while (timeLeftToRespawn > 0f)
        {
            timeLeftToRespawn -= Time.deltaTime;
            if (isPlayer)
            {
                TimeLeftToCloseUI = timeLeftToRespawn;
                OnPlayerRespawned?.Invoke();
            }
            yield return null;
        }

        Respawn(playerToRespawn, isPlayer);
    }

    private void Respawn(HumanStats playerToRespawn, bool isPlayer)
    {
        if (GameManager.GameState.EndOfRound == GameManager.Instance.CurrentGameState) return;
        if (isPlayer)
        {
            if (playerToRespawn.TeamUnit == HumanStats.Unit.CounterTerrorist)
            {
                _playerListCreator.SpawnHuman(ChooseUnit.Unit.CounterTerrorist, true);
            }
            else
            {
                _playerListCreator.SpawnHuman(ChooseUnit.Unit.Terrorist, true);
            }
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
        if (state)
        {
            _uiModeController.SetUIModeActive(UIModeController.UIMode.Restart, true);
        }
        else
        {
            _uiModeController.SetUIModeActive(UIModeController.UIMode.Restart, false);
        }
    }
}