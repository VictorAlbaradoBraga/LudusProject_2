using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgscroll2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1 * Time.deltaTime, 0);
        if (transform.position.x < -17.91)
        {
            transform.position = new Vector3(17.98f, transform.position.y);
        }
    }
}
