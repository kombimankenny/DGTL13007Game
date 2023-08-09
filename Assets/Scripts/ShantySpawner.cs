using UnityEngine;
using UnityEngine.SceneManagement;

public class ShantySpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab; // The prefab to spawn

    private GameObject spawnedObject; // Reference to the spawned object

    private void OnDestroy()
    {
        if (SceneManager.GetActiveScene().isLoaded)
        {
            if (objectPrefab != null)
            {
                spawnedObject = Instantiate(objectPrefab, transform.position, transform.rotation);

                // Register the spawned object for cleanup in the current scene
                SceneCleanup sceneCleanup = FindObjectOfType<SceneCleanup>();
                if (sceneCleanup != null)
                {
                    sceneCleanup.RegisterSpawnedObject(spawnedObject);
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        // Destroy the spawned object when the application quits
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
    }
}
