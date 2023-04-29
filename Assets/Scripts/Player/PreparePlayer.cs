using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _cameraHolder;
    [SerializeField] private GameObject _miniMapCameraHolder;
    [SerializeField] private GameObject _ui;
    //[SerializeField] private ChooseUnit _chooseUnit;
  
    private void Awake()
    {
        if (gameObject.CompareTag("Player"))
        {
            //_chooseUnit.OnUnitChosen += Prepare;
            _ui.SetActive(true);
            _cameraHolder.SetActive(true);
            _miniMapCameraHolder.SetActive(true);
        }
    }

    //private void Prepare(ChooseUnit.Unit unit)
    //{
    //    _cameraHolder.SetActive(true);
    //    _miniMapCameraHolder.SetActive(true);
    //}
    
}
