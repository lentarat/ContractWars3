using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounterShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ctKillCounterText;
    [SerializeField] private TextMeshProUGUI _tKillCounterText;
    private void Awake()
    {
        GameManager.Instance.OnSomeoneKilled += ShowKillCounter;
        GameManager.Instance.UpdateKillCounter(false, false);
    }

    private void ShowKillCounter(int terroristsKilled, int counterTerroristsKilled)
    {
        _tKillCounterText.text = terroristsKilled.ToString();
        _ctKillCounterText.text = counterTerroristsKilled.ToString();
    }
}
