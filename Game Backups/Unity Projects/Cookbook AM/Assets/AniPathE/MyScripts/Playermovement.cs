using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool isLeft, isRight, isJump,canJump = false;
    public bool isMove; 
    private Rigidbody2D rb;
    private SpriteRenderer sR; 

    private void Start()
    {
        sR = GetComponent<SpriteRenderer>(); 
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            isRight = true;
            isLeft = false;
            sR.flipX = false; 
            
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            isLeft = true;
            isRight = false;
            sR.flipX = true; 
        }
        else
        {
            isRight = false;
            isLeft = false; 
        }
        Debug.Log("Horizontal: " + Input.GetAxisRaw("Horizontal"));
        if (Input.GetAxisRaw("Jump") > 0 && !isJump)
        {
           canJump = true;
        }
        else
        {
            canJump = false; 
        }
        Debug.Log("Jump " + Input.GetAxisRaw("Jump"));
        isMove = isLeft || isRight; 

    }

    private void FixedUpdate()
    {
        MovePlayer(isLeft, isRight, canJump); 
    }

    private void MovePlayer(bool left, bool right, bool jump)
    {
        float dX = 0f;

        if (left) dX = -moveSpeed * Time.fixedDeltaTime;
        else if (right) dX = moveSpeed * Time.fixedDeltaTime;
        else dX = 0f; 
        if (jump)
        {
            isJump = true; 
            rb.AddForce(new Vector2(0f, jumpForce * Time.fixedDeltaTime),ForceMode2D.Impulse); 
        }
        Vector2 modVelocity = new Vector2(dX, rb.velocity.y);
        rb.velocity = modVelocity; 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJump = false; 
        }
    }

}
