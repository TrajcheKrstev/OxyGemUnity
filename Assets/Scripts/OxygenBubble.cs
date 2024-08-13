using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    public float floatSpeed = 2f;
    public float destroyHeight = 10f;

    void Update()
    {
        // Move the bubble upwards
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

        // Optional: Rotate the bubble for a floating effect
        transform.Rotate(Vector3.up * floatSpeed * 10 * Time.deltaTime);

        if (transform.position.y >= destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
