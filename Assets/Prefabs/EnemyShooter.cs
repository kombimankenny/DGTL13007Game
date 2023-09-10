using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public float shootingRate = 1f;
    public float projectileSpeed = 10f;
    public float maxShootDistance = 10f;
    public float movementSpeed = 5f;

    private float nextShootTime;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (player == null)
        {
            return; // Player not found, do nothing
        }

        // Rotate towards the player
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Move towards the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > maxShootDistance)
        {
            transform.position += directionToPlayer.normalized * movementSpeed * Time.deltaTime;
        }

        // Shooting logic
        if (distanceToPlayer <= maxShootDistance && Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + shootingRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new projectile at the shooter's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Set the velocity of the projectile
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = projectile.transform.right * projectileSpeed;

        // Ignore collisions between the shooter and its own bullets
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), projectile.GetComponent<Collider2D>());
    }
}
