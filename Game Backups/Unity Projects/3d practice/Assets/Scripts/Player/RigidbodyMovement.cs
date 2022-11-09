using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveMult = 3f;
    public int maxJumps = 1;
    public float jumpForce = 30f; 
    [SerializeField] private int jumps; 
    [SerializeField] private bool forward = false;
    [SerializeField] private bool back = false;
    [SerializeField] private bool left= false;
    [SerializeField] private bool right = false;
   // [SerializeField] private bool jump = false;
    bool canJump = false; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumps = maxJumps; 
    }
    // update is used to get input 
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forward = true; 
            back = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            back = true; 
            forward = false;
        }
        else
        {
            back = false;
            forward = false; 
        }
        if (Input.GetKey(KeyCode.A)){
            left = true;
            right = false; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            right = true;
            left = false; 
        }
        else
        {
            left = false;
            right = false; 
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse); 
            canJump = false; 
            jumps--; 
        }
        canJump = jumps > 0; 
       
       
    }
    private void MovePlayer(bool forward,bool backwards, bool left, bool right)
    {
        Vector3 mVector;
        float dX,dY,dZ = 0f;


        if (forward) dX = moveMult * Time.fixedDeltaTime;
        else if (back) dX = -moveMult * Time.fixedDeltaTime;
        else dX = 0f;

        if (left) dZ = moveMult * Time.fixedDeltaTime;
        else if (right) dZ = -moveMult * Time.fixedDeltaTime;
        else dZ = 0f;

        
        dY = rb.velocity.y; 
       
        mVector = new Vector3(dX, dY, dZ);
        rb.velocity = mVector; 
    }
    private void FixedUpdate()
    {
        MovePlayer(forward, back,left,right); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            canJump = true;
            jumps = maxJumps; 
        }
    }



}
