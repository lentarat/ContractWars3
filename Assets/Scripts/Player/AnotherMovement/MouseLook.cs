using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private float _mouseX;
    [SerializeField] private float _mouseY;
    [SerializeField] private float _sensitivity = 100f ;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }
     
    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        _playerBody.Rotate(Vector3.up * _mouseX);

    }
}
