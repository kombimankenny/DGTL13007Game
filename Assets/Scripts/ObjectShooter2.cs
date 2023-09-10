using UnityEngine;

public class ObjectShooter2 : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;    // The bullet prefab to spawn.
    public Transform firePoint;        // The position where bullets will be spawned.
    public float shootSpeed = 5f;      // The speed at which bullets are shot.

    [Header("Shooting Control")]
    public KeyCode fireKey = KeyCode.Space;   // The key to press to fire.
    public float creationRate = 0.5f;         // The rate of creation, as long as the key is pressed.

    private float lastShootTime;

    private void Update()
    {
        // Check if the fire key is pressed and if enough time has passed since the last shot.
        if (Input.GetKey(fireKey) && Time.time >= lastShootTime + creationRate)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Calculate the shooting direction based on the player's rotation.
        Vector2 shootingDirection = firePoint.up;

        // Create a new bullet instance.
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Get the Rigidbody2D of the bullet.
        Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();

        // Check if the bullet has a Rigidbody2D component.
        if (bulletRigidbody != null)
        {
            // Set the velocity of the bullet based on the calculated shooting direction and speed.
            bulletRigidbody.velocity = shootingDirection.normalized * shootSpeed;
        }

        // Update the last shoot time.
        lastShootTime = Time.time;
    }
}
