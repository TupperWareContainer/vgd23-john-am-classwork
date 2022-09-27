using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public RigidbodyMovement rigidbodyMovement;
    private Rigidbody2D rb;
    private float launchAngle;
    public float f_Mult;
    public GameObject aimpos; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //launchAngle = rigidbodyMovement.desiredAngle;
        //float d_x = Mathf.Sin(launchAngle * Mathf.Deg2Rad) * f_Mult;
        //float d_y = Mathf.Cos(launchAngle * Mathf.Deg2Rad) * f_Mult;
        transform.LookAt(aimpos.transform);
        rb.velocity = transform.forward * f_Mult;         
    }
}
