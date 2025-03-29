using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float smoothSpeed = 0.125f; 
    public Vector3 offset;
    private List<Transform> stackedItems = new List<Transform>(); // Toplanan eþyalar listesi


    void LateUpdate()
    {
        if (Target == null) return;

        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
       // transform.LookAt(Target);
    }
}
