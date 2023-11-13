using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void FixedUpdate()
    {
        if (target==null)
        {
            return;
        }
        Vector3 finalPos = target.position;
        finalPos.z = -10;
        transform.position = Vector3.Lerp(transform.position, finalPos, speed * Time.deltaTime);
    }
}
