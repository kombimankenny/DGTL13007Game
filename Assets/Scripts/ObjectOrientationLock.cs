using UnityEngine;

public class ObjectOrientationLock : MonoBehaviour
{
    public Quaternion fixedRotation; // The desired fixed rotation for the projectile

    private void Start()
    {
        // Set the initial rotation of the projectile to the desired fixed rotation
        transform.rotation = fixedRotation;
    }
}
