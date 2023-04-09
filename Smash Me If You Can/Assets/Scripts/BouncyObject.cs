using UnityEngine;

public class BouncyObject : MonoBehaviour
{
    [SerializeField] public float bounceMultiplier = 2.0f;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        Vector3 direction = Vector3.Reflect(rb.velocity.normalized, normal);

        rb.velocity = direction * (rb.velocity.magnitude * bounceMultiplier);
    }
}