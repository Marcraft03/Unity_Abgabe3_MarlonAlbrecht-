using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovementscript : MonoBehaviour
{
    private float direction;
    private float movementSpeed = 5f;
    public bool canmove = true;
    private Rigidbody2D rb;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float jumpForce = 12f;
    private bool isGrounded;

    private SpriteRenderer sr; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    { 
        if (canmove)
        {
            direction = 0;

            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
            }

            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }

            rb.linearVelocity = new Vector2(direction * movementSpeed, rb.linearVelocity.y);

            
            if (direction < 0f)
            {
                sr.flipX = true;
            }
            else if (direction > 0f)
            {
                sr.flipX = false;
            }
        }
    }

    private void Jump()
    {
        if (Physics2D.OverlapCircle(groundCheck.transform.position, 0.25f, groundLayer))
        {
            isGrounded = true;
        }

        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }   
}