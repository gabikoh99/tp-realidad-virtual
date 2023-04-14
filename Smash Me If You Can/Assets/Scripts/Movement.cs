// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Movement : MonoBehaviour 
// {
//     [SerializeField] private float movementSpeed = 50f;
//     private Rigidbody rb;

//         // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Vector3 direction = (-Vector3.forward) * Input.GetAxis("Vertical") + (-Vector3.right) * Input.GetAxis("Horizontal");
//         Move(direction);
//     }

//     public void Move(Vector3 direction)
//     {
//         rb.AddForce(direction * movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    [SerializeField] private float movementSpeed = 50f;
    [SerializeField] private float kickForce = 250f;
    [SerializeField] private float kickDistance = 100f;

    private Rigidbody rb;
    private Vector3 movementDirection = Vector3.zero;

    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.Find("Ball");
        print(ball);

    }

    // Update is called once per frame
    void Update()
    {
        //movementDirection = (-Vector3.forward) * Input.GetAxis("Vertical") + (-Vector3.right) * Input.GetAxis("Horizontal");

        // If the player is nearby the ball and presses the spacebar, kick the ball in the direction the player is facing
        if (Input.GetKeyDown(KeyCode.Space)) //&& Vector3.Distance(transform.position, ball.transform.position) < kickDistance)
        {
            if( Vector3.Distance(transform.position, ball.transform.position) < kickDistance){
                Kick();
            }
            //Kick();
        }
    }

    void FixedUpdate()
    {
        movementDirection = (-Vector3.forward) * Input.GetAxis("Vertical") + (-Vector3.right) * Input.GetAxis("Horizontal");
        Move(movementDirection);
    }

    public void Move(Vector3 direction)
    {
        rb.AddForce(direction * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void Kick()
    {
        Vector3 kickDirection = transform.forward;
        ball.GetComponent<Rigidbody>().AddForce(kickDirection * kickForce, ForceMode.Impulse);
    }
}
