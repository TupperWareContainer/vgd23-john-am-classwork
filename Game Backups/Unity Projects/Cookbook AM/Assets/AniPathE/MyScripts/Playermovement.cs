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
    public Animator ani;
    bool jump1, jump2, jump3 = false; 
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
        if(rb.velocity.y > 0)
        {
            jump2 = true; 
        }
        else if(rb.velocity.y < 0)
        {
            jump3 = true;
            jump1 = false; 
        }
        Debug.Log("Jump " + Input.GetAxisRaw("Jump"));
        isMove = (rb.velocity.x != 0) && !isJump;
        ani.SetBool("isJump", isJump); 
        ani.SetBool("IsRun", isMove);
        ani.SetBool("Jump1", jump1);
        ani.SetBool("Jump2", jump2);
        ani.SetBool("Jump3", jump3); 
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
            jump1 = true; 
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
            jump1 = false;
            jump2 = false;
            jump3 = false; 
        }
    }

}
