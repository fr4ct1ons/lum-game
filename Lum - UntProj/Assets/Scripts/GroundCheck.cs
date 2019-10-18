using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerController parent;

    private int numberOfColliders = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        numberOfColliders++;
        parent.CanJump();
        Debug.Log(numberOfColliders);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        numberOfColliders--;
        if (numberOfColliders < 1)
            parent.CannotJump();
    }
}
