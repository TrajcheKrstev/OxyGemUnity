using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLightRotation : MonoBehaviour
{
    public Transform lightLens;
    public float rotateSpeed;
    float angle;

    // Update is called once per frame
    void Update()
    {
        rotateVertical();
    }

    void rotateVertical()
    {
        angle = CameraManager.Instance.rotation.x;
        lightLens.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
    }
}
