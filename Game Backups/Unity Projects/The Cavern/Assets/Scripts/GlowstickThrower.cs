using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowstickThrower : MonoBehaviour
{
    public Transform parentTransform;
    public float launchForce = 1000f; 
    private Rigidbody rb; 
    public void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
      
        rb.AddRelativeForce((parentTransform.forward) * launchForce * Time.deltaTime,ForceMode.Impulse);
    }
}
