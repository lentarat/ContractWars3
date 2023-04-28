using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Crouch : MonoBehaviour, IPointerDownHandler
{

    public System.Action OnCrouchButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        //JumpPressed = true;
        OnCrouchButtonPressed();
        //Debug.Log("On Crouch Down");

    }

}
