using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PreparePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _cameraHolder;
    [SerializeField] private GameObject _miniMapCameraHolder;
    [SerializeField] private GameObject _ui;
    [SerializeField] private PlayerCCStateMachine _playerCCStateMachine;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private NavMeshController _navMeshController;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            //_chooseUnit.OnUnitChosen += Prepare;
            _ui.SetActive(true);
            _cameraHolder.SetActive(true);
            _miniMapCameraHolder.SetActive(true);
            _playerCCStateMachine.enabled = true;
            _characterController.enabled = true;
            _navMeshAgent.enabled = false;
            _navMeshController.enabled = false;
        }
    }    
}
