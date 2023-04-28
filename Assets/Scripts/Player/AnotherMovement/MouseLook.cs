using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private float _mouseX;
    [SerializeField] private float _mouseY;
    [SerializeField] private float _sensitivity = 100f ;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _xRotation = 0f;
    [SerializeField] private Camera _camera;


 
    // Start is called before the first frame update
    void Start()
    {

        // Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
            _mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _mouseX = 0f;
            _mouseY = 0f;
        }

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);







        _playerBody.Rotate(Vector3.up * _mouseX);

    }
}
