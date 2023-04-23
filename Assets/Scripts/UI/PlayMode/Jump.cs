using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _jumpPressed;
    public bool JumpPressed { get { return _jumpPressed; } private set { _jumpPressed = value; } }
    public System.Action OnJumpButtonPressed;
    public System.Action OnJumpButtonReleased;
    public void OnPointerDown(PointerEventData eventData)
    {
        //JumpPressed = true;
        OnJumpButtonPressed();
        Debug.Log("On Pointer Down");

    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        //JumpPressed = false;
        OnJumpButtonReleased();
        Debug.Log("On Pointer Up");
    }

    
}
