using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndOfRoundInfoShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private Color _counterTerroristColor;
    [SerializeField] private Color _terroristColor;

    private void Awake()
    {
        AssignWinner(); 
    }

    private void AssignWinner()
    {
        if (GameManager.Instance.CounterTerroristsKilled > GameManager.Instance.TerroristsKilled)
        {
            _winnerText.text = "Terrorists win";
            _winnerText.color = _terroristColor;
        }
        else if (GameManager.Instance.CounterTerroristsKilled < GameManager.Instance.TerroristsKilled)
        {
            _winnerText.text = "Counter-Terrorists win";
            _winnerText.color = _counterTerroristColor;
        }

        if (_winnerText.text == "")
        {
            _winnerText.text = "Draw";
        }
    }
}
