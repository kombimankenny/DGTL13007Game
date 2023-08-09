using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public string targetTag;            // Tag of the objects that trigger the sound
    public AudioClip collisionSound;    // Sound to play on collision

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = collisionSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            source.PlayOneShot(collisionSound);
        }
    }
}
