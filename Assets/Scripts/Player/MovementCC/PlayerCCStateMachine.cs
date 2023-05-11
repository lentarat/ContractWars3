using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCCStateMachine : MonoBehaviour
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
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded= value; } }

    [SerializeField] private float _jumpHeight = 3f;
    public float JumpHeight { get { return _jumpHeight; }set { _jumpHeight= value; } }

    [Header("Animation")]
    [SerializeField] private Animator _animator;
    public Animator CCAnimator { get { return _animator; } set { _animator = value; } }

    [SerializeField] public int _isWalkingHash;
    public int IsWalkingHash { get { return _isWalkingHash; } set { _isWalkingHash = value; } }

    [SerializeField] public int _isRunningHash;
    public int IsRunningHash { get { return _isRunningHash; } set { _isRunningHash = value; } }

    [SerializeField] public int _isJumpingHash;
    public int IsJumpingHash { get { return _isJumpingHash; } set { _isJumpingHash= value; } }

    [SerializeField] public int _isCrouchingHash;
    public int IsCrouchingHash { get { return _isCrouchingHash; } set { _isCrouchingHash = value; } }


    [Header("Input")]

    [SerializeField] private float _speed ;
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
    public bool IsCrouchPressed { get { return _isCrouchPressed; } set { _isCrouchPressed = value; } }

    public Vector3 move;

    private bool _requireNewJumpPress = true;
    public bool RequireNewJumpPress { get { return _requireNewJumpPress; } set { _requireNewJumpPress = value; } }

    [Header("UI Elements")]
    [SerializeField] private Joystick _joystick;
    public Joystick Joystick { get { return _joystick; } set { _joystick = value; } }

    [SerializeField] private Jump _jumpingButton;
    public Jump JumpingButton { get { return _jumpingButton; } set { _jumpingButton = value; } }

    [SerializeField] private Crouch _crouchButton;
    public Crouch CrouchButton { get { return _crouchButton; } set { _crouchButton = value; } }

    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }


    
    public string VerticalPatameterName { get { return _verticalPatameterName; } set { _verticalPatameterName = value; } }
    public string HorizontalPatameterName { get { return _horizontalPatameterName; } set { _horizontalPatameterName = value; } }

    [Header("Camera")]
    [SerializeField] private Transform _mainCamera;
    public Transform MainCamera { get { return _mainCamera;} set { _mainCamera = value; } }
    public Transform _LerpCameraFrom;
    public Transform _LerpCameraTo;

    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    private string _verticalPatameterName = "Vertical";
    private string _horizontalPatameterName = "Horizontal";

    [SerializeField] private bool _isPlayer;

    private void Start()
    {
        /*if (gameObject.CompareTag("Player"))
        {
            _isPlayer = true;
        }*/

        //_controller = GetComponent<CharacterController>();
       // _animator = GetComponent<Animator>();

        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
        IsJumpingHash = Animator.StringToHash("IsJumping");
        IsCrouchingHash = Animator.StringToHash("IsCrouching");

       /* if (_isPlayer)
        {
        }*/
            _jumpingButton.OnJumpButtonPressed += OnJumpClick;
            _jumpingButton.OnJumpButtonReleased += OnJumpReleased;
            _crouchButton.OnCrouchButtonPressed += OnCrouchClick;

        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();

    }

    private void OnDestroy()
    {
       /* if (_isPlayer)
        {
        }*/
            _jumpingButton.OnJumpButtonPressed -= OnJumpClick;
            _jumpingButton.OnJumpButtonReleased -= OnJumpReleased;
            _crouchButton.OnCrouchButtonPressed -= OnCrouchClick;
    }

    void Update()
    {
      /*  if (_isPlayer)
        {
        }*/
            OnInputHandler();
            _currentState.UpdateStates();
    }

    private void OnInputHandler()
    {
        
       // KeybordInput();
        JoystickInput(); 
    }

    private void KeybordInput()
    {
        /////////////////////////Walk
        _horizontalInput = Input.GetAxis(HorizontalPatameterName);
        _verticalInput = Input.GetAxis(VerticalPatameterName);
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
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJumpPressed = true;
            _requireNewJumpPress = false;
        }
       /* else
        {
            _isJumpPressed = false;
        }*/



        //////////////////////Crouch 

        if (Input.GetKeyDown(KeyCode.C))
        {

            if (_isCrouchPressed)
            {
                _isCrouchPressed = false;
            }
            else
            {
                _isCrouchPressed = true;
            }
        }

    }

    private void JoystickInput()
    {
        _horizontalInput = _joystick.Direction.x;
        _verticalInput = _joystick.Direction.y;
        _isMovementPressed = _horizontalInput != 0 || _verticalInput != 0;

    }


    private void OnJumpClick()
    {
        if (_requireNewJumpPress == true && _isGrounded)
        {
            _isJumpPressed = true;
            _requireNewJumpPress = false;
        }
        
    }

    private void OnJumpReleased()
    {
        _isJumpPressed = false;
        //_requireNewJumpPress = true;
    }

    private void OnCrouchClick()
    {
        if (_isCrouchPressed)
        {
            _isCrouchPressed = false;
        }
        else 
        {
            _isCrouchPressed = true;
        }
    }

}
