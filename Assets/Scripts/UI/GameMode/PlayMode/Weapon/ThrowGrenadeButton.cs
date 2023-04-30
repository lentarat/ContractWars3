using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowGrenadeButton :MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Grenade _grenade;
    [SerializeField] private GameObject _shootButton;
    [SerializeField] private GameObject _trowGrenadeButton;



    public void OnPointerDown(PointerEventData eventData)
    {
     

    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _grenade.StartThrowGrenade(); 
    }

}
