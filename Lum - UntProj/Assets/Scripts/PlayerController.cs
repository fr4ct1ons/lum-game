using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Vector2 jumpVector;

    private Vector2 inputVector;
    private PlayerInputs inputs;
    private Rigidbody2D myRigidbody;
    private bool canJump = false;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
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
        Debug.Log(canJump);
        Debug.Log(jumpVector);
        if(canJump)
            myRigidbody.AddForce(jumpVector);
    }

    private void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + (Time.deltaTime * speed * inputVector));
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
