using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveMult = 50f;
    public float jumpForce = 50f;
    private Rigidbody rb; 
    [SerializeField] bool left, right,forward, back, jump = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            forward = true;
            back = false; 
        }
        else if(Input.GetAxisRaw("Vertical") < 0)
        {
            back = true;
            forward = false; 
        }
        else
        {
            forward = false; 
            back = false; 
        }
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            right = true;
            left = false; 
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            left = true;
            right = false; 
        }
        else
        {
            left = false;
            right = false; 
        }
    }
    private void FixedUpdate()
    {
        MovePlayer(left, right, forward, back, jump);  
    }
    private void MovePlayer(bool isLeft, bool isRight, bool isForward, bool isBack, bool isJump)
    {
        float dX,dZ,dY = 0f;
        if (isLeft) dZ = -moveMult * Time.fixedDeltaTime;
        else if (isRight) dZ = moveMult * Time.fixedDeltaTime;
        else dZ = 0f;
        if (isForward) dX = moveMult * Time.fixedDeltaTime;
        else if (isBack) dX = moveMult * Time.fixedDeltaTime;
        else dX = 0f;
        dY = rb.velocity.y;

        Vector3 newVelocity = (transform.forward * dZ) + (transform.right * dX) + (transform.up * dY); 
        rb.velocity = newVelocity; 

    }
}
