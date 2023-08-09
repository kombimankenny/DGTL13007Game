using UnityEngine;
using System.Collections.Generic;

public class SceneCleanup : MonoBehaviour
{
    private static SceneCleanup instance;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        CleanupScene();
    }

    private void OnApplicationQuit()
    {
        CleanupScene();
    }

    private void CleanupScene()
    {
        // Clean up spawned objects
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        spawnedObjects.Clear();

        // Other cleanup tasks specific to the scene
        // ...
    }

    public void RegisterSpawnedObject(GameObject spawnedObject)
    {
        spawnedObjects.Add(spawnedObject);
    }
}
