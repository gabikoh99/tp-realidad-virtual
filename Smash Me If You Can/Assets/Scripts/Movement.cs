using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    [SerializeField] private float movementSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move(Vector3.forward * Input.GetAxis("Vertical"));
        Move(Vector3.right * Input.GetAxis("Horizontal"));
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}
