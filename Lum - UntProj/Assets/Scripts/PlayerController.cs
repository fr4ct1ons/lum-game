using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    Vector2 inputVector;
    PlayerInputs inputs;
    private Rigidbody2D myRigidbody;

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
}
