using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(Rigidbody))]
public class Player : MonoBehaviour, IControllable
{
    [SerializeField] private Stopwatch _stopwatch;

    [SerializeField] private float _gravityMod;
    [SerializeField] private float _dragInAir;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _moveForce;
    [SerializeField] private  float _jumpForce;
    [SerializeField] private float _xSensitivity;

    private Animator _animator;
    private Rigidbody _rb;
    private GroundChecker _groundChecker;

    private CollisionChecker _collionChecker;

    private bool _isGrounded;

    private float _dragOnGround;




    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _dragOnGround = _rb.drag;

        _groundChecker = GetComponent<GroundChecker>();

        _animator = GetComponentInChildren<Animator>();

        _collionChecker = GetComponent<CollisionChecker>();       
    }

    private void OnEnable()
    {
        _collionChecker.StartButtunPressedEvent += OnStartButtonPressed;
        _collionChecker.StopButtonPressedEvent += OnStopButtonPressedevent;     
               
    }
    

    private void OnDisable()
    {
        _collionChecker.StartButtunPressedEvent -= OnStartButtonPressed;
        _collionChecker.StopButtonPressedEvent -= OnStopButtonPressedevent;       
    }

    private void OnStopButtonPressedevent()
    {
        _stopwatch.Pause();        
    }

    private void OnStartButtonPressed()
    {     
        _stopwatch.StartTime();
    }

    private void Update()
    {
        _isGrounded = _groundChecker.IsGrounded;// WHY?
        _animator.SetBool("IsGrounded", _groundChecker.IsGrounded);
        ChangeDragInJump();
    }   

    public void Jump()
    {
        if (_groundChecker.IsGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); 
            
            _animator.SetTrigger("JumpUp");
           
        }
    }

    private void ChangeDragInJump()
    {
        if (_groundChecker.IsGrounded)
        {
            _rb.drag = _dragOnGround;       
        }
        else
            {
             _rb.drag = _dragInAir;
             _rb.AddForce(-Vector3.up * _gravityMod);
             }
    }


    public void Move(Vector3 direction)
    {
        if(direction== Vector3.zero)
        {          
            _animator.SetBool("IsRuning", false);
        }

        if (_isGrounded && direction != Vector3.zero)
        {
            _rb.AddRelativeForce(direction * _moveForce);

            if (_rb.velocity.magnitude >= _maxVelocity)
            {
                _rb.velocity = _rb.velocity.normalized * _maxVelocity;
            }   

        _animator.SetBool("IsRuning", true);
        }

    }    

    public void LookAt(float inputX)
    {
        if (_groundChecker.IsGrounded)
        {
            var direction = transform.forward;
            var rotation = Quaternion.Euler(0, inputX , 0);
            direction = rotation * direction;

            if (inputX != 0)
            {
                var targetRot = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(direction, Vector3.up), Time.fixedDeltaTime * _xSensitivity);          

                _rb.MoveRotation(targetRot);
            }
        }
    }
}
