using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int coins;
    // member variable for animations
    private Animator animator;

    // Public variables appear in the Inspector, so you can tweak them without editing code.
    public float moveSpeed = 4f;       // How fast the player moves left/right
    
    //Jump realated variables for the Jump Feature (later)
    public float jumpForce = 2f;      // How strong the jump is (vertical speed)
    public int extraJumpsValue = 1;        // How many extra jumps allowed (1 = double jump, 2 = triple jump)
    private int extraJumps;                // Counter for jumps left
    public Transform groundCheck;      // Empty child object placed at the player's feet
    public float groundCheckRadius = 0.2f; // Size of the circle used to detect ground
    public LayerMask groundLayer;      // Which layer counts as "ground" (set in Inspector)

    // Private variables are used internally by the script.
    private Rigidbody2D rb;            // Reference to the Rigidbody2D component
    private bool isGrounded;           // True if player is standing on ground

    void Start()
    {
        // Grab the Rigidbody2D attached to the Player object once at the start.
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // --- Horizontal movement ---
        // Get input from keyboard (A/D or Left/Right arrows).
        float moveInput = Input.GetAxis("Horizontal");
        // Apply horizontal speed while keeping the current vertical velocity.
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jump realated code for the Jump Feature (later)
        // --- Ground check ---
        // Create an invisible circle at the GroundCheck position.
        // If this circle overlaps any collider on the "Ground" layer, player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
           // Reset extra jumps when grounded
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        // --- Jump & Double Jump ---
        // If Space is pressed:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                // Normal jump
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (extraJumps > 0)
            {
                // Extra jump (double or triple depending on extraJumpsValue)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--; // Reduce available extra jumps
            }
        }
        // --- Jump ---
        // If player is grounded AND the Jump button (Spacebar by default) is pressed:
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Set vertical velocity to jumpForce (launch upward).
            // Horizontal velocity stays the same.
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // for animations
        SetAnimation(moveInput);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Run");
            }
        }
        else
        {
            if (rb.linearVelocityY > 0)
            {
                animator.Play("Player_Jump");
            } 
            else
            {
                animator.Play("Player_Fall");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bouncepad")
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 2);
        }
    }
}
