using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _chooseModeUI;
    [SerializeField] private GameObject _gameModeUI;

    private void Awake()
    {
        _chooseModeUI.SetActive(true);
        _gameModeUI.SetActive(false);


    }
}
