using UnityEngine;
using System.Collections.Generic;

public class ObjectCleanup : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>();

    public void RegisterSpawnedObject(GameObject spawnedObject)
    {
        spawnedObjects.Add(spawnedObject);
    }

    public void CleanupSpawnedObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        spawnedObjects.Clear();
    }
}
