using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float kickForce = 10f; // Force applied to the ball when kicked
    public Rigidbody ballRb; // Reference to the ball's rigidbody component

    private void Update()
    {
        // Get input axis values for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the player based on input axis values
        transform.Translate(new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime);

        // Check if space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Calculate the direction from the player to the ball
            Vector3 kickDirection = (ballRb.transform.position - transform.position).normalized;

            // Apply a force to the ball in the kick direction
            ballRb.AddForce(kickDirection * kickForce, ForceMode.Impulse);
        }
    }
}

