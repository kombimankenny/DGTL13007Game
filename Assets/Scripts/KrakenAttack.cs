using UnityEngine;

public class KrakenAttack : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply to the player on collision.
    public float pushForce = 10f; // Force to push the player.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the collided object is the player.
            HealthController playerHealth = other.GetComponent<HealthController>();
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();

            if (playerHealth != null)
            {
                // Apply damage to the player.
                playerHealth.TakeDamage(damageAmount);
            }

            if (playerRigidbody != null)
            {
                // Apply a force to push the player.
                Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
