using UnityEngine;

[AddComponentMenu("Playground/Movement/PlayerController")]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Physics2DObject
{
    [Header("Push")]
    public KeyCode pushKey = KeyCode.Space;
    public float pushStrength = 5f;
    public Enums.Axes pushAxis = Enums.Axes.Y;
    public bool relativePushAxis = true;

    [Header("Speed Boost")]
    public float speedBoostFactor = 2.0f; // Speed boost factor
    public float powerUpDuration = 5.0f;   // Duration of the power-up effect

    //private float originalSpeed;
    private float speedBoostEndTime;
    private Vector2 pushVector;
    private bool isPushing = false;

    // Read the input from the player
    private void Update()
    {
        isPushing = Input.GetKey(pushKey);

        if (Time.time > speedBoostEndTime)
        {
            // Power-up has expired, return to normal speed
            // Implement your logic to handle speed here
        }
    }

    // FixedUpdate is called every frame when the physics are calculated
    private void FixedUpdate()
    {
        // Handle pushing
        if (isPushing)
        {
            pushVector = Utils.GetVectorFromAxis(pushAxis) * pushStrength;

            // Apply the push
            if (relativePushAxis)
            {
                rigidbody2D.AddRelativeForce(pushVector);
            }
            else
            {
                rigidbody2D.AddForce(pushVector);
            }
        }

        // Handle speed boost effect
        if (Time.time <= speedBoostEndTime)
        {
            // Apply the speed boost by modifying the velocity
            Vector2 newVelocity = rigidbody2D.velocity * speedBoostFactor;
            rigidbody2D.velocity = newVelocity;
        }
    }

    // Apply the speed boost effect when collecting a power-up
    public void ApplySpeedBoost()
    {
        // Set the end time for the power-up effect
        speedBoostEndTime = Time.time + powerUpDuration;
    }

    private void Start()
    {
        //originalSpeed = 8;
    }

}
