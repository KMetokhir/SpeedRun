using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    private GameInput _gameInput;
    private IControllable _controllable;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _controllable = GetComponent<IControllable>();
        if(_controllable == null)
        {
            throw new Exception($"No Icontrollable component on {gameObject} gameobject");
        }
    }

    private void OnEnable()
    {
        _gameInput.GamePlay.Jump.performed += OnJumpPerformed;
    }
        

    private void OnDisable()
    {
        _gameInput.GamePlay.Jump.performed -= OnJumpPerformed;
    }

    private void FixedUpdate()
    {        
        MoveProcess();
        LookProcess();
    }
    

    private void MoveProcess()
    {
       var inputDirection = _gameInput.GamePlay.Movement.ReadValue<Vector2>();
       var direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
       _controllable.Move(direction);        
    }

    private void LookProcess()
    {
        var inputDirection = _gameInput.GamePlay.Look.ReadValue<Vector2>();
        _controllable.LookAt(inputDirection.x);
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        _controllable.Jump();
    }


}
