using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    public int maxJumps = 2; // Adjust this to set the maximum number of jumps.
    private int jumpsRemaining;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)
        {
            Vector2 jumpVector = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = new Vector2(rb.velocity.x, 0); // Clear vertical velocity before jumping.
            rb.AddForce(jumpVector, ForceMode2D.Impulse);
            jumpsRemaining--;
        }
    }

    // Assuming you have a ground check mechanism.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps; // Reset jumps when touching the ground.
        }
    }
}
