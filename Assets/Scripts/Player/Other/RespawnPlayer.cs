using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    //[SerializeField] private PlayerListCreator _playerListCreator;
    [SerializeField] private HumanStats _humanStats;
    [SerializeField] private GameObject _playModeUI;
    [SerializeField] private GameObject _deathModeUI;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _initialTimeToRespawn;

    public float TimeLeftToRespawn { get; private set; }

    public System.Action OnPlayerRespawn;

    private void Start()
    {
        //_humanStats.OnPlayerDeath += HandlePlayerDeath;
        TimeLeftToRespawn = _initialTimeToRespawn;
    }

    

    private void SetDeathMode(bool state)
    {
        _playModeUI.SetActive(!state);
        _deathModeUI.SetActive(state);
        _camera.enabled = !state;
    }

    private void Respawn()
    {
    }
}
