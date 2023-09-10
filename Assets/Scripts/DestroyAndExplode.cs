using UnityEngine;

public class DestroyAndExplode : MonoBehaviour
{
    public GameObject explosionPrefab; // Reference to the explosion prefab or animation object.

    private void OnDestroy()
    {
        Explode();
    }

    private void Explode()
    {
        // Instantiate the explosion prefab or play the animation.
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // Destroy this object.
        Destroy(gameObject);
    }
}
