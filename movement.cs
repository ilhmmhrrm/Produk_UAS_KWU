using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private GroundDetector groundDetector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundDetector = GetComponent<GroundDetector>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Gerakan horizontal
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Melompat jika player berada di atas tanah
        if (Input.GetButtonDown("Jump") && groundDetector.IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}