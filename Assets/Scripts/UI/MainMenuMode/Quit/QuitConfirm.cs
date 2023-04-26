using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitConfirm : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;

    [SerializeField] private Button YesButton;
    [SerializeField] private Button NoButton;

    private void Awake()
    {
        YesButton.onClick.AddListener(Quit);
        NoButton.onClick.AddListener(ReturnBack);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void ReturnBack()
    {
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
