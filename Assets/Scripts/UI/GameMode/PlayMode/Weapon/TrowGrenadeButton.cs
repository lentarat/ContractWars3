using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrowGrenadeButton : IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _shootButton;
    [SerializeField] private GameObject _trowGrenadeButton;

    [SerializeField] private WeaponController _weaponController;


    public void OnPointerDown(PointerEventData eventData)
    {
       _shootButton.SetActive(false);
       _trowGrenadeButton.SetActive(true);

    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _shootButton.SetActive(false);
        _trowGrenadeButton.SetActive(true);
    }

}
