using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    private int score = 0;

    //public GameOverScreen gameOver;
    public static ScoreManager Instance
    {
        get { return instance; }
    }

    public int Score
    {
        get { return score; }
    }

    [SerializeField] public int gameOverScore = 3; // Game over score

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            // Find the gameOverScreen object in the current scene
            //gameOver = FindObjectOfType<GameOverScreen>();
        }
        
        

    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;

        if (score >= gameOverScore)
        {
            
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public int GetScore()
    {
        return score;
    }
}
