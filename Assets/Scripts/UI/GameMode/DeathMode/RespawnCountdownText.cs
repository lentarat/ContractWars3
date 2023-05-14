using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnCountdownText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;

    private int _lastSecond;

    private void Update()
    {
        if (_lastSecond != (int)RespawnManager.Instance.TimeLeftToCloseUI)
        {
            _lastSecond = (int)RespawnManager.Instance.TimeLeftToCloseUI;
            _countdownText.text = "Respawning in " + (_lastSecond + 1).ToString() + "...";
        }
    }
}
