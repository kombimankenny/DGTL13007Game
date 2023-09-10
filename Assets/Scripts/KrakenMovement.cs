using UnityEngine;
using System.Collections;

public class KrakenMovement : MonoBehaviour
{
    public float pushForce = 5f;          // The force with which the Kraken pushes off.
    public float glideDrag = 0.5f;       // The drag to slow down the Kraken after pushing off.
    public float timeInterval = 5f;      // The time interval between movements.
    public string playerTag = "Player";  // The tag of the target object (player) to move toward.

    private Vector3 initialPosition;
    private Vector2 pushDirection;
    private float timer;

    private Rigidbody2D rb;
    private Transform targetObject;  // Reference to the target object (player).

    private void Start()
    {
        // Store the initial position of the Kraken.
        initialPosition = transform.position;

        // Get the Rigidbody2D component.
        rb = GetComponent<Rigidbody2D>();

        // Find the player object using its tag.
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        // Check if the player object was found.
        if (playerObject != null)
        {
            targetObject = playerObject.transform;

            // Start the movement coroutine.
            StartCoroutine(MoveTowardsPlayer());
        }
        else
        {
            Debug.LogWarning("Player object not found with tag: " + playerTag);
        }
    }

    private void FixedUpdate()
    {
        // Apply a constant force in the pushDirection.
        if (pushDirection != Vector2.zero)
        {
            rb.AddForce(pushDirection * pushForce);
        }

        // Apply drag to slow down the Kraken after pushing off.
        rb.velocity *= (1f - glideDrag);

        // Clamp velocity to prevent excessive speed.
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, pushForce);

        // Check if the Kraken has reached the target position (player).
        if (targetObject != null)
        {
            float distanceToPlayer = Vector2.Distance(rb.position, targetObject.position);
            if (distanceToPlayer <= 0.1f)
            {
                pushDirection = Vector2.zero;
            }
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        while (true)
        {
            if (targetObject != null)
            {
                // Wait for the specified time interval before moving.
                yield return new WaitForSeconds(timeInterval);

                // Set the pushDirection to move toward the player.
                pushDirection = (targetObject.position - transform.position).normalized;
            }
            else
            {
                // If the target object is null, stop the coroutine.
                yield break;
            }
        }
    }
}
