using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; 
    [Header("Preferences")]
    public float movementSpeed = 10f;
    public float jumpForce = 10f;
    public int maxJumps = 1;
    [SerializeField] private int jumps;

    [SerializeField] private bool forward, backward, left, right, isJump,canJump; 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumps = maxJumps; 
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                forward = true;
                backward = false;
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                backward = true;
                forward = false;
            }
        }
        else
        {
            backward = false;
            forward = false; 
        }
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                right = false;
                left = true; 
            }
            if(Input.GetAxisRaw("Horizontal") < 0)
            {
                left = false;
                right = true; 
            }
        }
        else
        {
            left = false;
            right = false; 
        }
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
        canJump = jumps > 0;
    }
    private void FixedUpdate()
    {
        MovePlayer(forward, backward, left, right,isJump && canJump); 
    }
    private void MovePlayer(bool forward, bool backward, bool left, bool right, bool jump)
    {
        float dX = 0f, dZ = 0f, dY = rb.velocity.y; 
        if (forward) dZ = movementSpeed * Time.fixedDeltaTime;
        
        else if (backward) dZ = -movementSpeed * Time.fixedDeltaTime;

        if (left) dX = movementSpeed * Time.fixedDeltaTime;

        else if (right) dX = -movementSpeed * Time.fixedDeltaTime;

        if (jump)
        {
            Debug.Log("Jump");
            dY = jumpForce * Time.fixedDeltaTime;
            jumps--;
        }

        Vector3 newVelocity = (transform.forward * dZ) + (transform.right * dX) + (transform.up * dY);
        rb.velocity = newVelocity; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            jumps = maxJumps;
            isJump = false; 
        }

    }

}
