using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _maxRunSpeed;
    public float MaxRunSpeed { get => _maxRunSpeed; set => _maxRunSpeed = value; }
    [SerializeField] private float _walkSpeed;
    public float MaxWalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    [SerializeField] private float _crouchedSpeed;
    public float MaxCrouchedSpeed { get => _crouchedSpeed; set => _crouchedSpeed = value; }
    [SerializeField] private float _crouchFrequency;
    public float CrouchFrequency { get => _crouchFrequency; set => _crouchFrequency = value; }
    [SerializeField] private float _jumpForce;
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    [SerializeField] private float _accelerationMultiplier;
    public float AccelerationMultiplier { get => _accelerationMultiplier; set => _accelerationMultiplier = value; }
    [SerializeField] private float _drag;
    public float Drag { get => _drag; set => _drag = value; }


    public Rigidbody Rigidbody;
    public Vector3 InputVector { get; set; }
    [HideInInspector] public int GroundLayer;
    [HideInInspector] public bool OnGround;
    
    public Transform FeetTransform;
    public Transform CameraTransform;
    public Transform LerpCameraFrom;
    public Transform LerpCameraTo;
    public float CameraLerpRatio;

    public IdleState IdleState = new IdleState();
    public RunState RunState = new RunState();
    public WalkState WalkState = new WalkState();
    public CrouchState CrouchState = new CrouchState();
    public JumpState JumpState = new JumpState();
    private IPlayerMovementState _currentState;

    private float _zeroVelocityThreshold = 0.001f;

    private void Start()
    {
        _currentState = WalkState;
        GroundLayer = LayerMask.NameToLayer("Ground");
        OnGround = true;
    }
    void Update()
    {
        GetInput();
        _currentState = _currentState.DoState(this);
        //Debug.Log(_currentState);
    }

    private void FixedUpdate()
    {
        ChangeVelocity();
    }

    private void GetInput()
    {
        InputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    private void ChangeVelocity()
    {
        if (InputVector == Vector3.zero)
        {
            Rigidbody.velocity -= Drag * new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);
        }
        else
        {
            Rigidbody.velocity += AccelerationMultiplier * InputVector;
        }

        if (Rigidbody.velocity.magnitude < _zeroVelocityThreshold)
        {
            Rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnGround = true;
        Debug.Log("OnGround true");
    }

    private void OnCollisionExit(Collision collision)
    {
        OnGround = false;
        Debug.Log("OnGround false");
    }
}
