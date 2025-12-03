using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int extraJumpsValue = 1;
    private int extraJumps;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    public float jumpForce = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //Check if GroundCheck overlaps with ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--;
            }
        }
    }
}
