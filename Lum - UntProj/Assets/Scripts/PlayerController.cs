using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] CharacterController2D controller;

    [SerializeField] float runSpeed = 40f;
    
    bool canJump = false;
    bool crouch = false;
    
    PlayerInputs inputs;
    Vector2 inputVector;
    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        inputs = new PlayerInputs();
        inputs.Gameplay.Move.performed += ctx =>
        {
            inputVector = ctx.ReadValue<Vector2>();
            inputVector.y = 0.0f;
        };
        inputs.Gameplay.Move.canceled += ctx => inputVector = Vector2.zero;
        inputs.Gameplay.Jump.performed += ctx => Jump();
    }

    private void Jump()
    {
        canJump = true;
    }

    private void FixedUpdate()
    {
        controller.Move(inputVector.x * runSpeed* Time.fixedDeltaTime, crouch, canJump);
        canJump = false;
    }

    private void OnEnable()
    {
        inputs.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputs.Gameplay.Disable();
    }

    public void CanJump()
    {
        canJump = true;
    }

    public void CannotJump()
    {
        canJump = false;
    }
}
