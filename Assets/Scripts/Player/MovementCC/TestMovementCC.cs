using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementCC : MonoBehaviour
{

    [SerializeField] private CharacterController _controller;
    public CharacterController Controller { get { return _controller; } set { _controller = value; } }




    [Header("Gravity")]
    [SerializeField] private float _gravity = -9.81f;
    public float Gravity { get { return _gravity; } set { _gravity = value; } }
    /// проблема модификатора доступа private 
    [SerializeField] public Vector3 _velocity;
    //public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }

    [SerializeField] private Transform _groundCheck;
    public Transform GroundCheck { get { return _groundCheck; } set { _groundCheck = value; } }

    [SerializeField] private float _groundDistance = 0.4f;
    public float GroundDistance { get { return _groundDistance; } set { _groundDistance = value; } }
    [SerializeField] private LayerMask _groundMask;
    public LayerMask GroundMask { get { return _groundMask; } set { _groundMask = value; } }
    [SerializeField] private bool _isGrounded;
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }

    [SerializeField] private float _jumpHeight = 3f;
    public float JumpHeight { get { return _jumpHeight; } set { _jumpHeight = value; } }

    [Header("Animation")]
    [SerializeField] private Animator _animator;
    public Animator CCAnimator { get { return _animator; } set { _animator = value; } }

    [SerializeField] public int _isWalkingHash;
    public int IsWalkingHash { get { return _isWalkingHash; } set { _isWalkingHash = value; } }

    [SerializeField] public int _isRunningHash;
    public int IsRunningHash { get { return _isRunningHash; } set { _isRunningHash = value; } }

    [SerializeField] public int _isJumpingHash;
    public int IsJumpingHash { get { return _isJumpingHash; } set { _isJumpingHash = value; } }

    [SerializeField] public int _isCrouchingHash;
    public int IsCrouchingHash { get { return _isCrouchingHash; } set { _isCrouchingHash = value; } }


    [Header("Input")]

    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } set { _speed = value; } }

    [SerializeField] private float _horizontalInput;
    public float HorizontalInput { get { return _horizontalInput; } set { _horizontalInput = value; } }
    [SerializeField] private float _verticalInput;
    public float VericalInput { get { return _verticalInput; } set { _verticalInput = value; } }

    [SerializeField] private bool _isMovementPressed = false;
    public bool IsMovementPressed { get { return _isMovementPressed; } set { _isMovementPressed = value; } }

    [SerializeField] private bool _isRunPressed = false;
    public bool IsRunPressed { get { return _isRunPressed; } set { _isRunPressed = value; } }

    [SerializeField] private bool _isJumpPressed = false;
    public bool IsJumpPressed { get { return _isJumpPressed; } set { _isJumpPressed = value; } }

    [SerializeField] private bool _isCrouchPressed = false;
    [SerializeField] private bool _isCrouchHandle = false;
    public bool IsCrouchPressed { get { return _isCrouchPressed; } set { _isCrouchPressed = value; } }

    public Vector3 move;

    private bool _requireNewJumpPress = true;
    public bool RequireNewJumpPress { get { return _requireNewJumpPress; } set { _requireNewJumpPress = value; } }




    [Header("Camera")]
    [SerializeField] private Transform _mainCamera;
    public Transform MainCamera { get { return _mainCamera; } set { _mainCamera = value; } }
    public Transform _LerpCameraFrom;
    public Transform _LerpCameraTo;




    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
        IsJumpingHash = Animator.StringToHash("IsJumping");
        IsCrouchingHash = Animator.StringToHash("IsCrouching");
    }

    void Update()
    {
        KeybordInput();
        Movement();
        GravityHandler();
    }

    private void KeybordInput()
    {
        /////////////////////////Walk
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _isMovementPressed = _horizontalInput != 0 || _verticalInput != 0;


        ///////////////////////Run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRunPressed = true;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRunPressed = false;
        }


        //////////////////////// jump
        if (Input.GetKeyDown(KeyCode.Space))
        {

            _isJumpPressed = true;
            _requireNewJumpPress = false;

        }
        else
        {
            _isJumpPressed = false;
        }



        //////////////////////Crouch 

        if (Input.GetKeyDown(KeyCode.C))
        {

            if (_isCrouchPressed)
            {
                _isCrouchPressed = false;
                _isCrouchHandle = true;
            }
            else
            {
                _isCrouchPressed = true;
                _isCrouchHandle = false;
            }
        }

    }


    void Movement()
    {
        if (_isMovementPressed)
        {
            
            CCAnimator.SetFloat("Horizontal", HorizontalInput);
            CCAnimator.SetFloat("Vertical", VericalInput);
            Controller.Move(move * (Speed) * Time.deltaTime);
        }

        if (_isRunPressed)
        {
            CCAnimator.SetFloat("Horizontal", HorizontalInput);
            CCAnimator.SetFloat("Vertical", VericalInput);

            move = (gameObject.transform.right * HorizontalInput) + (gameObject.transform.forward * VericalInput);
            Controller.Move(move * (Speed) * Time.deltaTime);
        }

        if (_isJumpPressed)
        {
            CCAnimator.SetBool(IsJumpingHash, true);

            _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            Controller.Move(move * (Speed) * Time.deltaTime);

        }
        else 
        {
            CCAnimator.SetBool(IsJumpingHash, false);

        }

        if (_isCrouchPressed)
        {
            CCAnimator.SetBool(IsCrouchingHash, true);
            //Speed = Speed / 2;
            //Controller.height = Controller.height / 1.4f;
            //Controller.center = Controller.center / 2;
            //MainCamera.transform.position = _LerpCameraTo.transform.position;
            Controller.Move(move * (Speed) * Time.deltaTime);
        }
        else 
        {
            CCAnimator.SetBool(IsCrouchingHash, false);
            //Speed = Speed * 2;
            //Controller.height = Controller.height * 1.4f;
            //Controller.center = Controller.center * 2;
            //MainCamera.transform.position = _LerpCameraFrom.transform.position;
            Controller.Move(move * (Speed) * Time.deltaTime);
        }
    }

    private void GravityHandler()
    {

        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (IsGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += Gravity * Time.deltaTime;
        Controller.Move(_velocity * Time.deltaTime);
    }

}
