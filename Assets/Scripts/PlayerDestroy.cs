using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroy : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // The name of the scene to load after player destruction

    private void OnDestroy()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}