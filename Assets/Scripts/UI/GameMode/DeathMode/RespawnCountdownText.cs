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
        int lastSecond = (int)_respawnPlayer.TimeLeftToRespawn;
        while (_respawnPlayer.TimeLeftToRespawn > 0f)
        {
            if ((int)_respawnPlayer.TimeLeftToRespawn != lastSecond)
            {
                _textMeshProUGUI.text = "Respawning in " + ((int)_respawnPlayer.TimeLeftToRespawn + 1).ToString() + "...";
            }
            yield return null;
        }
        _textMeshProUGUI.text = "Respawning in 0...";
        yield return null;
    }
}
