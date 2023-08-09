using UnityEngine;

[AddComponentMenu("Playground/Movement/Camera Follow")]
public class CameraFollow : MonoBehaviour
{
    [Header("Object to follow")]
    public Transform target;

    public bool limitBounds = false;
    public float left = -5f;
    public float right = 5f;
    public float bottom = -5f;
    public float top = 5f;

    private Vector3 lerpedPosition;
    private Camera cameraComponent;

    private void Awake()
    {
        cameraComponent = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
            lerpedPosition.z = -10f;
        }

        if (limitBounds)
        {
            Vector3 bottomLeft = UnityEngine.Camera.main.ScreenToWorldPoint(Vector3.zero);
            Vector3 topRight = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Camera.main.pixelWidth, UnityEngine.Camera.main.pixelHeight));
            Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

            Vector3 boundPosition = transform.position;
            if (boundPosition.x > right - (screenSize.x / 2f))
            {
                boundPosition.x = right - (screenSize.x / 2f);
            }
            if (boundPosition.x < left + (screenSize.x / 2f))
            {
                boundPosition.x = left + (screenSize.x / 2f);
            }

            if (boundPosition.y > top - (screenSize.y / 2f))
            {
                boundPosition.y = top - (screenSize.y / 2f);
            }
            if (boundPosition.y < bottom + (screenSize.y / 2f))
            {
                boundPosition.y = bottom + (screenSize.y / 2f);
            }
            transform.position = boundPosition;
        }
        else
        {
            transform.position = lerpedPosition;
        }
    }
}
