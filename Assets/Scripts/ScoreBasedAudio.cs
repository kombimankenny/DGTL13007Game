using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBasedAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] scoreAudioClips; // Assign your audio clips in the inspector
    public AudioClip defaultAudioClip;
    public ScoreManager scoreManager; // Assign your ScoreManager in the inspector
    private int playerScore;

    void Start()
    {
        if (scoreManager == null)
        {
            Debug.LogWarning("Score Manager is not assigned.");
            return;
        }

        // Get the player's score from the assigned ScoreManager
        playerScore = ScoreManager.Instance.GetScore();
        Debug.Log("Player Score: " + playerScore); // Add this line to check the player's score.

        // Play audio based on player's score
        PlayAudioBasedOnScore();

        // Start the WaitForAudio coroutine
        StartCoroutine(WaitForAudio());
    }

    void PlayAudioBasedOnScore()
    {
        // Ensure you have audio clips assigned for different score levels
        if (scoreAudioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips assigned for score levels.");
            return;
        }

        // Check the player's score and play the corresponding audio clip
        if (playerScore >= 0 && playerScore < scoreAudioClips.Length)
        {
            audioSource.clip = scoreAudioClips[playerScore];
            audioSource.Play();
            Debug.Log("Playing audio for score: " + playerScore); // Add this line to check which audio is being played.
        }
        else
        {
            Debug.LogWarning("Score is out of range for audio clips.");
        }

        // Start the WaitForAudio coroutine
        StartCoroutine(WaitForAudio());
    }

    IEnumerator WaitForAudio()
    {
        // Wait for the audio to finish playing.
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // After the audio finishes, play default audio if available.
        if (defaultAudioClip != null)
        {
            audioSource.clip = defaultAudioClip;
            audioSource.Play();
        }
    }
}
