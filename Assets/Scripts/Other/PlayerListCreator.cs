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
    [SerializeField] private ChooseUnit _chooseUnit; // reference vs static action?
   // private Transform randomSpawnPosition;



    private void Awake()
    {
        _chooseUnit.OnUnitChosen += AddPlayer;
       

    }
    private void Start()
    {
        _chooseUnit.OnUnitChosen += SetPlayers;
        RespawnManager.Instance.OnCountdownElapsed += AddPlayer;
    }

    private void OnDestroy()
    {
        _chooseUnit.OnUnitChosen -= AddPlayer;
        _chooseUnit.OnUnitChosen -= SetPlayers;

    }

    //private void AddPlayer(ChooseUnit.Unit unit)
    //{
    //    if (unit == ChooseUnit.Unit.CounterTerrorist)
    //    {
    //        //Instantiate(_ctBody, _ctPlayersHolder).tag = "Player";
    //        Instantiate(_ctBody, _ctPlayersHolder).tag = "Player";

    //    }
    //    else
    //    {
    //        //Instantiate(_tBody, _tPlayersHolder).tag = "Player";
    //        //Instantiate(_tBody, _tPlayersHolder).tag = "Player";
    //        Instantiate(_tBody, _tBotsSpawnPoints[Random.Range(0, 5)].position, Quaternion.identity, _tBotsHolder);
    //    }

    //    //creating bots after players

    //    for (int i = _tPlayersHolder.GetComponentsInChildren<WeaponController>().Length; i < _tMaxNumber; i++)
    //    {
    //        //var randomSpawnPosition = new Vector3(Random.Range(4, 16), 1, Random.Range(-17, -19));
    //        Instantiate(_tBody, _tBotsSpawnPoints[Random.Range(0,5)].position, Quaternion.identity, _tBotsHolder);
    //    }
    //    for (int i = _ctPlayersHolder.GetComponentsInChildren<WeaponController>().Length; i < _ctMaxNumber; i++)
    //    {
    //        Instantiate(_ctBody, _ctBotsSpawnPoints[Random.Range(0, 5)].position, Quaternion.identity, _ctBotsHolder);
    //    }
    //}

    private void AddPlayer(ChooseUnit.Unit unit)
    {
        SpawnHuman(unit, true);

        //creating bots after players

        for (int i = _tPlayersHolder.GetComponentsInChildren<WeaponController>().Length; i < _tMaxNumber; i++)
        {
            //var randomSpawnPosition = new Vector3(Random.Range(4, 16), 1, Random.Range(-17, -19));
            SpawnHuman(ChooseUnit.Unit.Terrorist, false);
        }
        for (int i = _ctPlayersHolder.GetComponentsInChildren<WeaponController>().Length; i < _ctMaxNumber; i++)
        {
            SpawnHuman(ChooseUnit.Unit.Terrorist, false);
        }
    }

    private void SpawnHuman(ChooseUnit.Unit unit, bool isPlayer)
    {
        GameObject spawnedPlayer;
        if (unit == ChooseUnit.Unit.CounterTerrorist)
        {
            spawnedPlayer = Instantiate(_ctBody, _ctBotsSpawnPoints[Random.Range(0, 5)].position, Quaternion.identity, _ctBotsHolder);
        }
        else
        {
            spawnedPlayer = Instantiate(_tBody, _tBotsSpawnPoints[Random.Range(0, 5)].position, Quaternion.identity, _tBotsHolder);
        }
        if (isPlayer)
        {
            spawnedPlayer.tag = "Player";
        }
    }

    private void SetPlayers(ChooseUnit.Unit unit)
    {
        HumanStats[] players = gameObject.GetComponentsInChildren<HumanStats>();
        PlayerList.Instance.SetPlayersOnTheMap(players);
    }
}
