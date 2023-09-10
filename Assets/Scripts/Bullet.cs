using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private string targetTag = "Enemy"; // Set the target tag in the Inspector.
    
    [Header("Bullet Owner")]
    [SerializeField] private GameObject owner; // The object that fired the bullet

    public void SetOwner(GameObject ownerObject)
    {
        owner = ownerObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag) && other.gameObject != owner)
        {
            HealthController healthController = other.GetComponent<HealthController>();
            if (healthController != null)
            {
                int damageToDeal = GetDamage(); // Use the GetDamage method to get the damage amount.
                healthController.TakeDamage(damageToDeal);
            }

            // Destroy the bullet on impact.
            //Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}
