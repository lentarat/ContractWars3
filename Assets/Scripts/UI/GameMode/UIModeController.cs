using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModeController : MonoBehaviour
{
    [SerializeField] private GameObject _chooseMode;
    [SerializeField] private GameObject _restartMode;
    [SerializeField] private GameObject _endOfRoundMode;
    
    //[SerializeField] private PreparePlayer _preparePlayer;

    private UIMode _currentUIMode = UIMode.Restart;

    public enum UIMode
    {
        Restart,
        UnitChoose,
        EndOfRound
    }
    
    public void SetUIModeActive(UIMode uiMode, bool state)
    {
        if (_currentUIMode != uiMode)
        {
            SetUIModeActive(_currentUIMode, false);
            _currentUIMode = uiMode;
        }
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
