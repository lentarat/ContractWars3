using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnCountdownText : MonoBehaviour
{
    [SerializeField] private RespawnPlayer _respawnPlayer;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    private void Awake()
    {
        _respawnPlayer.OnPlayerRespawn += HandlePlayerRespawnTimeCountdown;
    }
    private void HandlePlayerRespawnTimeCountdown()
    {
        StartCoroutine(ShowCountdownText());
    }

    private IEnumerator ShowCountdownText()
    {
        while (_respawnPlayer.TimeLeftToRespawn > 0f)
        {
            _textMeshProUGUI.text = "Respawning in " + (_respawnPlayer.TimeLeftToRespawn).ToString() + "...";
            yield return null;
        }
        _textMeshProUGUI.text = "Respawning in 0...";
        yield return null;
    }
}
