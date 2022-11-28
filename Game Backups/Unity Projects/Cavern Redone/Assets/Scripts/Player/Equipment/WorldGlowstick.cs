using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGlowstick : MonoBehaviour
{
    private static float launchForce = 200f;
    private static float spinForce = 50f;
    float timer = 0f;
    float maxTime = 20f;
    bool hasCollided = false; 
    Rigidbody rb; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(launchForce * Time.fixedDeltaTime, 0f, 0f), ForceMode.Impulse);
        rb.AddRelativeTorque(new Vector3(0f, 0f, spinForce * Time.fixedDeltaTime), ForceMode.Impulse); 
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer > (maxTime *.5) && hasCollided)
        {
            Destroy(gameObject); 
        }
        else if(timer > maxTime)
        {
            Destroy(gameObject); 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        hasCollided = true; 
    }

}
