using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundObject : MonoBehaviour
{
    public Transform target;  // The object to rotate around
    public float rotationSpeed = 5f;
    public float rotationDuration = 5f;  // Time in seconds for one full rotation

    private float elapsedTime = 0f;

    void Update()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the rotation angle based on elapsed time and duration
        float rotationAngle = (360f / rotationDuration) * Time.deltaTime;

        // Rotate the camera around the target object
        transform.RotateAround(target.position, Vector3.up, rotationAngle);

        // Reset elapsed time after one full rotation
        if (elapsedTime >= rotationDuration)
        {
            elapsedTime = 0f;
        }
    }
}
