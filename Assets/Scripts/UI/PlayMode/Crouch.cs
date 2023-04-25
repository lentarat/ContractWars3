using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Crouch : MonoBehaviour, IPointerDownHandler
{
    /*[SerializeField] private bool _crouchPress;
    public bool CrouchPress { get { return _crouchPress; } private set { _crouchPress = value; } }*/
    public System.Action OnCrouchButtonPressed;
   // public System.Action OnCrouchButtonReleased;
    public void OnPointerDown(PointerEventData eventData)
    {
        //JumpPressed = true;
        OnCrouchButtonPressed();
        Debug.Log("On Crouch Down");

    }

   /* public void OnPointerUp(PointerEventData eventData)
    {
        //JumpPressed = false;
        OnCrouchButtonReleased();
        Debug.Log("On Crouch Up");
    }*/
}
