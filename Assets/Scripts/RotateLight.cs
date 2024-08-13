using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public Transform lightPole;
    public float rotateSpeed;
    float angle;
    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        rotateHozirontal();

    }

    void rotateHozirontal()
    {
        transform.rotation = Quaternion.identity;

        angle = CameraManager.Instance.yRotation.y;
        lightPole.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
