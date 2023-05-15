using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModeController : MonoBehaviour
{
    [SerializeField] private GameObject _chooseMode;
    [SerializeField] private GameObject _restartMode;
    [SerializeField] private GameObject _endOfRoundMode;

    private UIMode _currentUIMode;

    public enum UIMode
    {
        Restart,
        UnitChoose,
        EndOfRound
    }

    //public void SetAllUIModesInactive()
    //{
    //    _chooseMode.SetActive(false);
    //}
    public void SetUIModeInactive(UIMode uiMode)
    {
        switch (uiMode)
        {
            case UIMode.UnitChoose:
                {
                    _chooseMode.SetActive(false);
                }
                break;
            case UIMode.Restart:
                {
                    _restartMode.SetActive(false);
                }
                break;
            case UIMode.EndOfRound:
                {
                    _endOfRoundMode.SetActive(false);
                }
                break;
            default:
                { Debug.Log("null"); break; }
        }
    }

    public void ChangeUIMode(UIMode uiMode)
    {
        SetUIModeActive(_currentUIMode, false);
        _currentUIMode = uiMode;
        SetUIModeActive(uiMode, true);
    }

    private void SetUIModeActive(UIMode uiMode, bool state)
    {
        switch (uiMode)
        {
            case UIMode.UnitChoose:
                {
                    _chooseMode.SetActive(state);
                }
                break;
            case UIMode.Restart:
                {
                    _restartMode.SetActive(state);
                }
                break;
            case UIMode.EndOfRound:
                {
                    _endOfRoundMode.SetActive(state);
                }
                break;
            default:
                { Debug.Log("null"); break; }
        }
    }
}
