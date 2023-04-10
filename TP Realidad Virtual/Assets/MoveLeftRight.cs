using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveLeftRight : MonoBehaviour
{
    public float speed = 5f; // Speed of the movement
    public float distance = 5f; // Distance to move in each direction

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Store the initial position of the object
    }

    void Update()
    {
        // Calculate the horizontal movement using a sine wave
        float xMovement = Mathf.Sin(Time.time * speed) * distance;

        // Set the new position of the object
        transform.position = new Vector3(startPosition.x + xMovement, transform.position.y, transform.position.z);
    }
}

