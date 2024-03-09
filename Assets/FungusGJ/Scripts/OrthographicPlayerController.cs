using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float jumpForce = 8f; // Adjust the jump force as needed
    public LayerMask groundLayer;

    private bool isGrounded;

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);

        // Move the player
        MovePlayer();

        // Make the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player in the orthographic view
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // Apply a vertical force to simulate jumping
        GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
    }
}
