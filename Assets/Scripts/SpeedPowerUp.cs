using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the power-up object
            gameObject.SetActive(false);

            // Apply the speed boost to the player's ship
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.ApplySpeedBoost();
            }
            
            // Destroy the power-up object
            Destroy(gameObject);
        }
    }
}
