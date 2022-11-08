using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveMult = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    


}
