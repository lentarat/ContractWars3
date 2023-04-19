using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTimeShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private float _countdownTime;

    private int _minutes;
    private int _seconds;
    private int _lastSecond;

    private void Start()
    {
        _lastSecond = (int)_countdownTime % 60;
    }

    private void Update()
    {
        _countdownTime -= Time.deltaTime;

        _minutes = (int)(_countdownTime / 60f);
        _seconds = (int)_countdownTime % 60;

        if (_lastSecond != _seconds)
        {
            _lastSecond = _seconds;
            _countdownText.text = string.Format("{0:0}:{1:00}", _minutes, _seconds);
            //_countdownText.text = string.Concat(_minutes.ToString(), ":", _seconds.ToString());
        }
    }
}
