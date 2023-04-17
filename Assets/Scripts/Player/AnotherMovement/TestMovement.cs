using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _verticalInput;
    [SerializeField] private Rigidbody _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); 
        _verticalInput = Input.GetAxis("Vertical");

        _player.velocity = new Vector3((_horizontalInput * _speed) * Time.deltaTime, 0f, (_verticalInput * _speed ) * Time.deltaTime); 
        
    }
}
