using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothen = 0.125f;
    public Vector3 offset;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothenedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothen);
        transform.position = smoothenedPosition;
        
    }
}
