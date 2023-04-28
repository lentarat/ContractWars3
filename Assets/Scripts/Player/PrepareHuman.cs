using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareHuman : MonoBehaviour
{
    [SerializeField] private GameObject CameraHolder;
    [SerializeField] private GameObject MiniMapCameraHolder;
    [SerializeField] private GameObject _ui;
    [SerializeField] private PlayerCCStateMachine _playerCCStateMachine;
    private void Awake()
    {
        if (gameObject.CompareTag("Player"))
        {
            Instantiate(_ui, transform);

            CameraHolder.AddComponent<Camera>();

            Camera minimapCamera = MiniMapCameraHolder.AddComponent<Camera>();
            minimapCamera.orthographicSize = 10f;

            //_playerCCStateMachine.Joystick
        }
    }
}
