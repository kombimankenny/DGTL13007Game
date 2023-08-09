using UnityEngine;
using TMPro;

public class ScoreTextUpdater : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Shanty Pages: " + ScoreManager.Instance.Score.ToString() + "/" + ScoreManager.Instance.gameOverScore.ToString();
        }
    }
}
