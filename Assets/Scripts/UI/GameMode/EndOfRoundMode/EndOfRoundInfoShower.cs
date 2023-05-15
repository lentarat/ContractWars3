using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndOfRoundInfoShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winnerText;

    private void Awake()
    {
        //GameManager.Instance.OnRoundCountdownElapsed += SetMeActive;

        

        //gameObject.SetActive(false);
      
    }
}
