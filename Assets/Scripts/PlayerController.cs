using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0f, 0f, verticalInput) * moveSpeed * Time.deltaTime);
        transform.Translate(new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime);
        // Jump when spacebar is pressed
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            animator.SetTrigger("jumping");
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            
            PlayAnimation("Jump1");
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayAnimation("Jump3");

        }

        if (Input.GetKey(KeyCode.S))
        {
            PlayAnimation("Jump2");

        }
        if (Input.GetKey(KeyCode.D))
        {
            
            PlayAnimation("Jump3");

        }



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            animator.SetTrigger("jumping");
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void PlayAnimation(string animationName)
    {
        // Trigger the specified animation
        if (animator != null)
        {
            animator.Play(animationName);
        }
        else
        {
            Debug.LogError("Animator component not found!");
        }
    }
}

