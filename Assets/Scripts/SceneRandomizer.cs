using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomizer : MonoBehaviour
{
    [SerializeField] private string[] scenesToLoad; // Array of scene names to randomly select from

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string sceneToLoad = scenesToLoad[Random.Range(0, scenesToLoad.Length)];
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
