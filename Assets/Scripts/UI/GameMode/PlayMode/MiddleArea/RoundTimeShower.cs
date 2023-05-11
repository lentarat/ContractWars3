using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTimeShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;

    private void Start()
    {
        GameManager.Instance.OnSecondElapsed += UpdateTimer;
    }
    private void UpdateTimer(int minutes, int seconds)
    {
        _countdownText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
