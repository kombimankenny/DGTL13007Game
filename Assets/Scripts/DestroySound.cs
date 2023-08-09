using UnityEngine;

public class DestroySound : MonoBehaviour
{
    public AudioClip destroySound;   // Sound to play on object destruction

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;   // Ensure that the audio source does not play on awake
        source.clip = destroySound;   // Set the audio clip
    }

    private void OnDestroy()
    {
        if (destroySound != null)
        {
            source.enabled = true;    // Enable the audio source
            source.Play();            // Play the sound
            source.enabled = false;   // Disable the audio source
        }
    }
}
