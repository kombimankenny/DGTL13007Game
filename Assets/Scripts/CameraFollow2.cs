using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform target;         // The object the camera will follow
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector3 offset;           // Offset from the target position

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Keep the camera at a constant z-coordinate for a top-down view
        smoothedPosition.z = transform.position.z;

        transform.position = smoothedPosition;
    }
}
