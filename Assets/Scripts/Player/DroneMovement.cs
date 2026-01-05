using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public float moveForce = 20f;
    public float maxSpeed = 10f;
    public float verticalForce = 15f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Horizontal movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(moveX, 0, moveZ) * moveForce;
        rb.AddForce(force, ForceMode.Acceleration);

        // Vertical movement
        if (Input.GetKey(KeyCode.E))
            rb.AddForce(Vector3.up * verticalForce, ForceMode.Acceleration);
        else if (Input.GetKey(KeyCode.Q))
            rb.AddForce(Vector3.down * verticalForce, ForceMode.Acceleration);

        // Speed limit
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
