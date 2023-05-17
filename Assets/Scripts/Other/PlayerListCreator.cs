using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListCreator : MonoBehaviour
{
    [SerializeField] private GameObject _ctBody;
    [SerializeField] private GameObject _tBody;
    [SerializeField] private Transform _ctBotsHolder;
    [SerializeField] private Transform _tBotsHolder;
    [SerializeField] private Transform[] _tBotsSpawnPoints;
    [SerializeField] private Transform[] _ctBotsSpawnPoints;
    [SerializeField] private Transform _ctPlayersHolder;
    [SerializeField] private Transform _tPlayersHolder;
    [SerializeField] private int _ctMaxNumber;
    [SerializeField] private int _tMaxNumber;
    [SerializeField] private ChooseUnit _chooseUnit;
   
    private void Awake()
    {
        CleanPlayerList();
        _chooseUnit.OnUnitChosen += InitializePlayerList;
    }
    private void OnDestroy()
    {
        _chooseUnit.OnUnitChosen -= InitializePlayerList;
    }

    public void SpawnHuman(ChooseUnit.Unit unit, bool isPlayer)
    {
        GameObject spawnedPlayer;
        if (unit == ChooseUnit.Unit.CounterTerrorist)
        {
            spawnedPlayer = Instantiate(_ctBody, _ctBotsSpawnPoints[Random.Range(0, 5)].position, Quaternion.identity, _ctBotsHolder);
            if (isPlayer)
            {
                spawnedPlayer.tag = "Player";
                spawnedPlayer.transform.SetParent(_ctPlayersHolder);
            }
        }
        else
        {
            spawnedPlayer = Instantiate(_tBody, _tBotsSpawnPoints[Random.Range(0, 5)].position, Quaternion.identity, _tBotsHolder);
            if (isPlayer)
            {
                spawnedPlayer.tag = "Player";
                spawnedPlayer.transform.SetParent(_tPlayersHolder);
            }
        }
        PlayerList.Instance.Players.Add(spawnedPlayer?.GetComponent<HumanStats>());
    }

    private void InitializePlayerList(ChooseUnit.Unit unit)
    {
        SpawnHuman(unit, true);

        //creating bots after players

        for (int i = _tPlayersHolder.GetComponentsInChildren<WeaponController>().Length; i < _tMaxNumber; i++)
        {
            SpawnHuman(ChooseUnit.Unit.Terrorist, false);
        }
        for (int i = _ctPlayersHolder.GetComponentsInChildren<WeaponController>().Length; i < _ctMaxNumber; i++)
        {
            SpawnHuman(ChooseUnit.Unit.CounterTerrorist, false);
        }
    }

    private void CleanPlayerList()
    {
        PlayerList.Instance.CleanPlayerList();
    }
}
