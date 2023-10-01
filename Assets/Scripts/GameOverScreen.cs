using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;
    private ScoreManager scoreManager;
    private static GameOverScreen instance;
    public TextMeshProUGUI hasWonTextBox;

    //[SerializeField] private GameObject prefab; // Reference to the prefab

    private GameObject gameoverScreenInstance; // Instance of the game over screen

    public static GameOverScreen Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        //Checks if score has won
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager != null && scoreManager.Score == scoreManager.gameOverScore)
        {
            ShowGameOverScreen(true);
        }
    }

    public void ShowGameOverScreen(bool hasWon)
    {
    gameOverUI.SetActive(true);
        if (hasWon)
        {
            hasWonTextBox.text = "Congratulations! You have completed the ultimate shanty!";// Logic for showing a "Victory" screen

        }
        else
        {
            hasWonTextBox.text = "Oh no! You sank to the bottom of the briny depths";// Logic for showing a "Game Over" screen
        }


    }


    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        scoreManager.ResetScore();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Restart the game here
        // You can load the first scene or restart from a specific checkpoint or level

        // For example, if you have a GameManager script that manages game progression:
        // GameManager.Instance.RestartGame();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        scoreManager.ResetScore();
        // Quit the game here
        // You can exit the application or go back to the main menu

        // For example, if you have a GameManager script that manages game progression:
        // GameManager.Instance.QuitGame();
    }
}
