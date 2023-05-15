using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfRoundButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _restartRoundButton;
    [SerializeField] private Button _quitToMenuButton;

    private void Awake()
    {
        _restartRoundButton.onClick.AddListener(HandleRestartRoundButtonClick);
        _quitToMenuButton.onClick.AddListener(HandleQuitToMenuButtonClick);
    }

    private void HandleRestartRoundButtonClick()
    {
        ScenesManager.Instance.LoadGame();
    }

    private void HandleQuitToMenuButtonClick()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
}
