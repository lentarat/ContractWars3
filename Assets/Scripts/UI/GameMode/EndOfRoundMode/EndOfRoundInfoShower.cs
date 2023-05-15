using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndOfRoundInfoShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private Button _restartRoundButton;
    [SerializeField] private Button _quitToMenuButton;
    

    private void Awake()
    {
        //GameManager.Instance.OnRoundCountdownElapsed += SetMeActive;

        _restartRoundButton.onClick.AddListener(HandleRestartRoundButtonClick);
        _quitToMenuButton.onClick.AddListener(HandleQuitToMenuButtonClick);

        //gameObject.SetActive(false);
      
    }

    private void HandleRestartRoundButtonClick()
    {
        ScenesManager.Instance.LoadMap();
    }

    private void HandleQuitToMenuButtonClick()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
}
