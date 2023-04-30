using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _cameraHolder;
    [SerializeField] private GameObject _miniMapCameraHolder;
    [SerializeField] private GameObject _ui;
  
    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            //_chooseUnit.OnUnitChosen += Prepare;
            _ui.SetActive(true);
            _cameraHolder.SetActive(true);
            _miniMapCameraHolder.SetActive(true);
        }
    }    
}
