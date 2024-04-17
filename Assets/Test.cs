using UnityEngine;

public class Car : MonoBehaviour
{
    public float forwardForce = 1000f;
    public float backwardForce = 500f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get user input for movement and rotation
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // Apply forces for forward or backward movement
        if (moveInput > 0)
        {
            rb.AddForce(transform.forward * moveInput * forwardForce * Time.fixedDeltaTime);
        }
        else if (moveInput < 0)
        {
            rb.AddForce(transform.forward * moveInput * backwardForce * Time.fixedDeltaTime);
        }

        // Rotate the car left or right only if moving forward
        if (Vector3.Dot(rb.velocity, transform.forward) > 0)
        {
            float rotation = rotateInput * rotationSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0, rotation, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
