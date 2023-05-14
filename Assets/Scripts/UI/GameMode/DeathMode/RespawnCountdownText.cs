using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnCountdownText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;

    private float _countdownTime;
    private int _lastSecond;
    //private void Awake()
    //{
    //    _respawnPlayer.OnPlayerRespawn += HandlePlayerRespawnTimeCountdown;
    //}
    //private void HandlePlayerRespawnTimeCountdown()
    //{
    //    StartCoroutine(ShowCountdownText());
    //}

    private void Update()
    {
        Debug.Log(_lastSecond + " " +(int)RespawnManager.Instance.TimeLeftToRespawn);
        if (_lastSecond != (int)RespawnManager.Instance.TimeLeftToRespawn)
        {
            _lastSecond = (int)RespawnManager.Instance.TimeLeftToRespawn;
            _countdownText.text = _lastSecond.ToString();
        }

        //_countdownTime -= Time.deltaTime;
        //if (_countdownTime > 0f)
        //{
        //    int lastSecond = (int)_countdownTime;
        //}
    }


    //private IEnumerator ShowCountdownText()
    //{
    //    int lastSecond = (int)_respawnPlayer.TimeLeftToRespawn;
    //    while (_respawnPlayer.TimeLeftToRespawn > 0f)
    //    {
    //        if ((int)_respawnPlayer.TimeLeftToRespawn != lastSecond)
    //        {
    //            _textMeshProUGUI.text = "Respawning in " + ((int)_respawnPlayer.TimeLeftToRespawn + 1).ToString() + "...";
    //        }
    //        yield return null;
    //    }
    //    _textMeshProUGUI.text = "Respawning in 0...";
    //    yield return null;
    //}
}
