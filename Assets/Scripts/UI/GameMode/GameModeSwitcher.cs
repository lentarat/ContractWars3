using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _chooseModeUI;
    [SerializeField] private GameObject _playModeUI;

    [SerializeField] private ChooseUnit _chooseUnit;


    //private void Awake()
    //{
    //    _chooseModeUI.SetActive(true);
    //    _playModeUI.SetActive(false);

    //    _chooseUnit.OnUnitChosen += SwitchToPlayMode;
    //}

    private void SwitchToPlayMode(ChooseUnit.Unit unit)
    {
        _chooseModeUI.SetActive(false);
        _playModeUI.SetActive(true);

        //if (unit == ChooseUnit.Unit.T)
        //{
        //    _tBody.SetActive(true);
        //    _ctBody.SetActive(false);
        //}
        //else
        //{
        //    _tBody.SetActive(false);
        //    _ctBody.SetActive(true);
        //}
    }
}
