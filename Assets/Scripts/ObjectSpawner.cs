using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnProperties
{
    public GameObject prefab;
    public float spawnDelay = 1f;
    public float spawnDistance = 5f;
    public int maxSpawnCount = 10;
}

public class ObjectSpawner : MonoBehaviour
{
    public SpawnProperties[] spawnPropertiesArray; // Array of prefab spawn properties
    public float despawnDistanceThreshold = 30f; // Distance threshold for despawning objects

    public GameObject mainCamera; // Reference to the camera (assign in the Unity editor)

    private Transform player; // Reference to the player's transform

    private Dictionary<GameObject, List<GameObject>> spawnedObjects; // Dictionary to store spawned objects for each prefab

    private void Start()
    {
        spawnedObjects = new Dictionary<GameObject, List<GameObject>>();

        // Spawn objects based on spawn properties
        foreach (SpawnProperties spawnProperties in spawnPropertiesArray)
        {
            float spawnDelay = spawnProperties.spawnDelay;
            StartCoroutine(SpawnObjectRoutine(spawnProperties, spawnDelay));
        }
    }

    private void Update()
    {
        // Check if player transform is null
        if (player == null)
        {
            // Handle the case when the player object is destroyed
            GameObject newPlayer = GameObject.FindGameObjectWithTag("Player");

            if (newPlayer != null)
            {
                player = newPlayer.transform;
            }
            else
            {
                // Player object is still not found, do nothing
                return;
            }
        }

        DespawnObjectsOutsideDistance();
    }

    private System.Collections.IEnumerator SpawnObjectRoutine(SpawnProperties spawnProperties, float delay)
    {
        GameObject prefab = spawnProperties.prefab;
        float spawnDistance = spawnProperties.spawnDistance;
        int maxSpawnCount = spawnProperties.maxSpawnCount;

        spawnedObjects[prefab] = new List<GameObject>();

        while (true)
        {
            yield return new WaitForSeconds(delay);

            List<GameObject> prefabObjects = spawnedObjects[prefab];

            if (prefabObjects.Count < maxSpawnCount)
            {
                Vector3 spawnPosition = GetRandomSpawnPositionOutsideCamera(spawnDistance);
                GameObject spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
                prefabObjects.Add(spawnedObject);

                spawnedObjects[prefab] = prefabObjects;
            }
        }
    }

    private Vector3 GetRandomSpawnPositionOutsideCamera(float spawnDistance)
    {
        Vector3 cameraPosition = mainCamera.transform.position;

        // Generate random angle in radians
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        // Calculate spawn position based on angle and distance
        float spawnX = cameraPosition.x + spawnDistance * Mathf.Cos(randomAngle);
        float spawnY = cameraPosition.y + spawnDistance * Mathf.Sin(randomAngle);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        return spawnPosition;
    }

    /*private void Update()
    {
        // Check if player transform is null
        if (player == null)
        {
            // Handle the case when player object is destroyed
            GameObject newPlayer = GameObject.FindGameObjectWithTag("Player");

            if (newPlayer != null)
            {
                player = newPlayer.transform;
            }
            else
            {
                // Player object is still not found, do nothing
                return;
            }
        }

        DespawnObjectsOutsideDistance();
    }
    */

    private void DespawnObjectsOutsideDistance()
    {
        float sqrDespawnDistanceThreshold = despawnDistanceThreshold * despawnDistanceThreshold;

        // Create a separate list to store the prefab keys
        List<GameObject> prefabKeys = new List<GameObject>(spawnedObjects.Keys);

        foreach (GameObject prefab in prefabKeys)
        {
            List<GameObject> prefabObjects = spawnedObjects[prefab];

            for (int i = prefabObjects.Count - 1; i >= 0; i--)
            {
                GameObject spawnedObject = prefabObjects[i];

                if (spawnedObject != null)
                {
                    float sqrDistance = (spawnedObject.transform.position - player.position).sqrMagnitude;

                    if (sqrDistance > sqrDespawnDistanceThreshold)
                    {
                        Destroy(spawnedObject);
                        prefabObjects.RemoveAt(i);
                    }
                }
                else
                {
                    prefabObjects.RemoveAt(i);
                }
            }

            spawnedObjects[prefab] = prefabObjects;
        }
    }

}
