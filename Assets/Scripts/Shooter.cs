using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public Transform firePoint; // Point from where the projectiles are fired
    public float fireRate = 1f; // Rate of fire (in seconds)
    public float projectileSpeed = 10f; // Speed of the projectiles

    private float fireTimer; // Timer to control firing rate

    private void Start()
    {
        fireTimer = 0f;
    }

    private void Update()
    {
        // Update the fire timer
        fireTimer += Time.deltaTime;

        // Check if enough time has passed to fire
        if (fireTimer >= 1f / fireRate)
        {
            // Fire a projectile
            Fire();

            // Reset the fire timer
            fireTimer = 0f;
        }
    }

    public void Fire()
    {
        // Create a projectile at the fire point
        GameObject projectileObject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the projectile's rigidbody component
        Rigidbody2D projectileRigidbody = projectileObject.GetComponent<Rigidbody2D>();

        // Set the projectile's velocity to move it forward
        projectileRigidbody.velocity = transform.up * projectileSpeed;
    }

    public void Aim(Vector3 direction)
    {
        // Calculate the angle between the shooter's forward direction and the desired direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the shooter to face the desired direction
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
