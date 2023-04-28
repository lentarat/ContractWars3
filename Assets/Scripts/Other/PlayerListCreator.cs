using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListCreator : MonoBehaviour
{
    [SerializeField] private GameObject _ctPlayer;
    [SerializeField] private GameObject _tPlayer;
    [SerializeField] private GameObject _ctBotsHolder;
    [SerializeField] private GameObject _tBotsHolder;
    [SerializeField] private int _ctMaxNumber;
    [SerializeField] private int _tMaxNumber;

    private void Awake()
    {
        //creating bots after players
        for (int i = _tBotsHolder.GetComponentsInChildren<WeaponController>().Length; i < _ctMaxNumber; i++)
        {
            Instantiate(_tPlayer, _tBotsHolder.transform);   
        }
    }
}
