using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private List<string> levelNames = new List<string>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoadRandomLevel();
        }
    }

    private void LoadRandomLevel()
    {
        if (levelNames.Count > 0)
        {
            int randomIndex = Random.Range(0, levelNames.Count);
            string randomLevelName = levelNames[randomIndex];
            SceneManager.LoadScene(randomLevelName);
        }
        else
        {
            Debug.LogError("No level names provided in the list.");
        }
    }
}
