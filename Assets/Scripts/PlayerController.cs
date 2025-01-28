using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform character;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Interaction Settings")]
    public GameObject interactionPopup;
    public KeyCode interactKey = KeyCode.E;
    public SpriteRenderer BatteryColor;
    public int BatteryPower;
    private bool flipped = false;

    private Switches switche;
    private bool interactable = false;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    [SerializeField] private int catsRescued;

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

        if(!flipped && moveInput == 1)
        {
            flipped = true;
            character.localScale = new Vector2(1,1);
        }
        else if (flipped && moveInput == -1)
        {
            flipped = false;
            character.localScale = new Vector2(-1, 1);
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(interactKey) && interactable && switche != null)
        {
            Debug.Log("Interact button pressed");
            switche.Interacted(ref BatteryPower, ref BatteryColor);
            interactionPopup.SetActive(false);
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
        if (other.CompareTag("Switch"))
        {
            switche = other.GetComponent<Switches>();
            interactable = true;
            interactionPopup.SetActive(switche.Interactable());
        }
        else if (other.CompareTag("Cat"))
        {
            catsRescued++;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited trigger: " + other.gameObject.name);
        if (other.CompareTag("Switch"))
        {
            switche = null;
            interactable = false;
            interactionPopup.SetActive(false);
        }
    }
}
