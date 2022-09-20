using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = 2.0f * Mathf.Cos(Time.time);
        float y = 2.0f * Mathf.Sin(Time.time);
        float z = 2.0f * Mathf.Tan(Time.time);
        transform.position = new Vector3(x, y, z);
    }
}
