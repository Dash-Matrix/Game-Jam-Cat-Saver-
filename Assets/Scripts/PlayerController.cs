using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Interaction Settings")]
    public KeyCode interactKey = KeyCode.E;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    private void HandleMovement()
    {
        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 (A) to 1 (D)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Interact button pressed");
            // Add interaction logic here
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger: " + other.gameObject.name);
        // Add trigger enter logic here
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited trigger: " + other.gameObject.name);
        // Add trigger exit logic here
    }
}
