using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCCStateMachine : MonoBehaviour
{



    [SerializeField] private CharacterController _controller;
    public CharacterController Controller { get { return _controller; } set { _controller = value; } }

    [SerializeField] private float _horizontalInput;
    public float HorizontalInput { get { return _horizontalInput; } set { _horizontalInput = value; } }
    [SerializeField] private float _verticalInput;
    public float VericalInput { get { return _verticalInput; } set { _verticalInput = value; } }

    [SerializeField] private float _speed = 15f;
    public float Speed { get { return _speed; } set { _speed = value; } }

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

    [SerializeField] private Animator _animator;
    public Animator Animator { get { return _animator; } set { _animator = value; } } 

    private int _isWalkingHash;
    public int IsWalkingHash { get { return _isWalkingHash; } set { _isWalkingHash = value; } }
    private int _isRunningHash;
    public int IsRunningHash { get { return _isRunningHash; } set { _isRunningHash = value; } }
    private int _isJumpingHash;
    public int IsJumpingHash { get { return _isJumpingHash; } set { _isJumpingHash= value; } }

    private bool _isMovementPressent = false;
    public bool IsMovementPressent { get { return _isMovementPressent; } set { _isMovementPressent= value; } }
    private bool _isRunPressent = false;
    public bool IsRunPressent { get { return _isRunPressent; } set { _isRunPressent = value; } }

    private bool _isJumpPressent = false;
    public bool IsJumpPressent { get { return _isJumpPressent; } set { _isJumpPressent = value; } }

    [SerializeField] private bool _isJumpPressed = false;
    public bool IsJumpPressed { get { return _isJumpPressed; } set { _isJumpPressed = value; } }

    private bool _requireNewJumpPress = false;
    public bool RequireNewJumpPress { get { return _requireNewJumpPress; } set { _requireNewJumpPress = value; } }



    PlayerBaseState _currentState;
    PlayerStateFactory _states;


    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _isWalkingHash = Animator.StringToHash("IsWalking");
        _isRunningHash = Animator.StringToHash("IsRunning");
        _isJumpingHash = Animator.StringToHash("IsJumping");

        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnInputHandler();
       // GravityHandler();
        _currentState.UpdateStates();
    }

    private void OnInputHandler()
    {

        //Walk
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _isMovementPressent = _horizontalInput != 0 || _verticalInput != 0;

        //Run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //_isMovementPressent = false;
            _isRunPressent = true;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //_isMovementPressent = true;
            _isRunPressent = false;
        }

        // jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
            _requireNewJumpPress = false;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumpPressed = false;
        }
    }


    private void GravityHandler()
    {

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y += _gravity * Time.deltaTime;


        _controller.Move(_velocity * Time.deltaTime);
    }

}
