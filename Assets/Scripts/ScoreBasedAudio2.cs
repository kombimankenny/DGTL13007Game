using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBasedAudio2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] scoreAudioClips;
    public AudioClip defaultAudioClip;
    public ScoreManager scoreManager; // Assign your ScoreManager in the inspector
    private int playerScore;
    private bool scoreAudioPlayed = false;

    void Start()
    {
        playerScore = ScoreManager.Instance.GetScore();
        // Play score-based audio when the level is loaded
        PlayScoreBasedAudio();
    }

    void PlayScoreBasedAudio()
    {
        if (scoreAudioPlayed || scoreAudioClips.Length == 0)
        {
            // If score-based audio has been played or no clips are assigned, switch to default audio
            if (defaultAudioClip != null)
            {
                audioSource.clip = defaultAudioClip;
                audioSource.Play();
            }
        }
        else
        {
            // Play the score-based audio and set the flag to true
            audioSource.clip = scoreAudioClips[playerScore];
            audioSource.Play();
            scoreAudioPlayed = true;
        }
    }
}
