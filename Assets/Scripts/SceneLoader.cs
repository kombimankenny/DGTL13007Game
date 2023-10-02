using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Serialized field for scene name

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
