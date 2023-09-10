using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    // Scroll speed of the texture
    public float scrollSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the offset based on time and scroll speed
        float offset = Time.time * scrollSpeed;

        // Create a new material and set the offset
        Material material = GetComponent<Renderer>().material;
        Vector2 offsetVector = new Vector2(offset, 0f); // Change Y-axis to 0f
        material.SetTextureOffset("_MainTex", offsetVector);
    }
}
