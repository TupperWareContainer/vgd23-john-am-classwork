using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveMult = 3f;
    public float jumpForce = 10f; 
    public bool isLeft, isRight, isUp = false;
    public bool canClimb = false;
    public bool canJump = false; 
   
    private Rigidbody2D rb;
    Vector2 climbOffsett;
    Vector2 jumpOffsett; 
    public Vector2 boxSize;
    public Vector2 boxSizeJump; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        canClimb = Physics2D.BoxCast(climbOffsett, boxSize, 0f, Vector2.up);
        canJump = Physics2D.BoxCast(jumpOffsett, boxSizeJump, 0f, Vector2.down);
        climbOffsett = new Vector2(transform.position.x, transform.position.y + (transform.lossyScale.y/2));
        jumpOffsett = new Vector2(transform.position.x, -(transform.position.y - (transform.lossyScale.y/2)));
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            isRight = true;
            isLeft = false; 
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            isLeft = true;
            isRight = false; 
        }
        else
        {
            isRight = false;
            isLeft = false; 
        }
        if(Input.GetAxisRaw("Jump") > 0 && canJump)
        {
            isUp = true; 
        }
        else
        {
            isUp = false; 
        }
        
    }
    private void FixedUpdate()
    {

        
        MovePlayer(isLeft, isRight, isUp); 
    }
    private void MovePlayer(bool left, bool right, bool up)
    {
        float dX = 0;
        float dY =0; 
       
        if (left)
        {
            dX = -moveMult * Time.fixedDeltaTime; 
        }
        if (right)
        {
            dX = moveMult * Time.fixedDeltaTime; 
        }
        
        if (up)
        {
            rb.AddForce(new Vector2(0f, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
            dY = rb.velocity.y; 
            Debug.Log("Jump"); 
        }
        else
        {
            dY = rb.velocity.y;
        }
       
        Vector2 newVelocity = new Vector2(dX,dY);
        rb.velocity = newVelocity; 
    }
}
