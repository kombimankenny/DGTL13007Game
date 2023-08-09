using UnityEngine;
public enum ObjectType
{
    Pirate,
    PirateShip,
    EnemyBoss
}
public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    public GameOverScreen gameOver;
    [SerializeField] private ObjectType objectType;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        if (objectType == ObjectType.PirateShip)
        {
        // Logic for the object's death
        gameOver.ShowGameOverScreen(false);
        Destroy(gameObject);
        }
        
        else if (objectType == ObjectType.Pirate)
        {
        // Logic for the object's death
        Destroy(gameObject);
        }

        if (objectType == ObjectType.EnemyBoss)
        {
        // Logic for the object's death
        
        Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            if (bullet != null)
            {
                TakeDamage(bullet.GetDamage());
               
            }
        }
        else if (other.gameObject.CompareTag("HealthPack"))
        {
            HealthPack healthPack = other.gameObject.GetComponent<HealthPack>();

            if (healthPack != null)
            {
                Heal(healthPack.GetHealAmount());
                Destroy(other.gameObject);
            }
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
