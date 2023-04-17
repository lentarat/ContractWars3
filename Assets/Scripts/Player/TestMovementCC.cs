using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementCC : MonoBehaviour
{

    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _verticalInput;

    [SerializeField] private CharacterController _controller;


    [SerializeField] private float _speed = 15f;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Vector3 _velocity;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private bool _isGrounded;

    [SerializeField] private float _jumpHeight = 3f;

    [SerializeField] private Animator _animator;

    private int _isWalkingHash;
    private int _isRunningHash;

    [SerializeField] private bool _isMovementPresent;
    [SerializeField] private bool _isRuningPresent;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _isWalkingHash = Animator.StringToHash("IsWalking");
        _isRunningHash = Animator.StringToHash("IsRunning");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);


        MovementHandler();
        RunHandler();
        JumpHandler();
        AnimationHandler();
    }

    private void FixedUpdate()
    {
        GravityHandler();
        
    }

    private void AnimationHandler()
    {
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool isRunning = _animator.GetBool(_isRunningHash);

        if (_isMovementPresent && !isWalking)
        {
            _animator.SetBool(_isWalkingHash, true);
        }
        else if (!_isMovementPresent && isWalking)
        {
            _animator.SetBool(_isWalkingHash, false);
        }
        if (_isRuningPresent && !isRunning && _isMovementPresent )
        {
            _animator.SetBool(_isRunningHash, true);
        }
        else if (!_isRuningPresent && isRunning )
        {
            _animator.SetBool(_isRunningHash, false);
        }
    }

    private void MovementHandler()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * _horizontalInput + transform.forward * _verticalInput;

        _controller.Move(move * _speed * Time.deltaTime);
        _isMovementPresent = _horizontalInput != 0 || _verticalInput != 0;
    }

    private void RunHandler()
    {   
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //_isMovementPresent = false;
            _isRuningPresent = true;
            _speed += 5f;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //_isMovementPresent = true;
            _isRuningPresent = false;
            _speed -= 5f;
        }
    }

    private void JumpHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }
    private void GravityHandler()
    {

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += _gravity * Time.fixedDeltaTime ;

        _controller.Move(_velocity * Time.fixedDeltaTime);
    }    
}
