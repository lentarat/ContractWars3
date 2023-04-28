using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CurrentWeaponButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private WeaponChange _weaponChange;
    [SerializeField] private float _secondsToElapseToOpenInventory;

    private IEnumerator _buttonBehaviourCoroutine;
    
    private float _buttonClickedTime;
    private bool _buttonReleased = true;

    private void Awake()
    {
        _buttonBehaviourCoroutine = ButtonBehaviour();
        _weaponChange.SetCurrentWeaponFromInventory(_weaponChange.MainWeaponHolder);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonReleased = false;
        _buttonClickedTime = Time.time;
        StartCoroutine(_buttonBehaviourCoroutine);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _buttonReleased = true;
        StopCoroutine(ButtonBehaviour());
    }

    private IEnumerator ButtonBehaviour()
    {
        while (true)
        {
            if (Time.time > _buttonClickedTime + _secondsToElapseToOpenInventory)
            {
                _weaponChange.SetInventoryActive(true);
                StopCoroutine(_buttonBehaviourCoroutine);
            }
            else if (_buttonReleased && !_weaponChange.GetInventoryState())
            {
                _weaponChange.SetCurrentWeaponFromInventory(_weaponChange.PreviousWeaponHolder);
                StopCoroutine(_buttonBehaviourCoroutine);
            }
            yield return null;
        }
    } 
}
