using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float speed = 0.15f;
    public Transform target;
    [Range(1, 10)]
    public float smoothFactor;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;


    private void FixedUpdate()
    {
        if (Gamecontroller.instance.follow == true)
        {
            Follow();
        }

    }

    // Update is called once per frame
    void Follow()
    {
        Vector3 offset = new Vector3(0, 0, target.position.z);
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime) + offset;
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
        
    }
}
