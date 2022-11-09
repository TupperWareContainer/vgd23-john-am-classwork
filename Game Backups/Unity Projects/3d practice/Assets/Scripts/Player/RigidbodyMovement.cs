using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveMult = 3f;
    [SerializeField] private bool forward = false; 
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    // update is used to get input 
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) forward = true;
        else forward = false; 
    }
    private void MovePlayer(bool forward,bool up)
    {
        Vector3 mVector;
        float dX,dY,dZ = 0f;


        if (forward) dX = moveMult * Time.fixedDeltaTime;
        else dX = 0f;
        if (up) dY = moveMult * Time.fixedDeltaTime;
        else dY = rb.velocity.y;
        mVector = new Vector3(dX, dY, dZ);
        rb.velocity = mVector; 
    }
    private void FixedUpdate()
    {
        MovePlayer(forward, false); 
    }




}
