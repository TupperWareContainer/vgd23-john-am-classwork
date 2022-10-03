using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    public float moveMult = 3f;
    public Rigidbody2D rb2D;
    private bool isLeft, isRight, isJump = false;
    public float speedLimit = 5f;
    public float jumpMult = 1f;
    public int jumps = 1;
    private int maxJumps;
    bool isBoing;
    public SpriteRenderer playerSprite;  
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; /// the timescale is set to 1 whenever the level is loaded as a consequence of the player possibly reloading the level from another where the timescale is set to zero
        maxJumps = jumps; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            isLeft = false;
            isRight = true;
            Debug.Log("Right");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isRight = false;
            isLeft = true;
            Debug.Log("Left");
        }
        else
        {
            isLeft = false;
            isRight = false;
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && rb2D.velocity.y < speedLimit && rb2D.velocity.y > -speedLimit && jumps > 0 )
        {
            isJump = true;
            jumps--; 
        }
        else{
            isJump = false; 
        }

        Jump(isJump); 
    }
    private void FixedUpdate()
    {
        if (!isBoing)
        {
            MovePlayer(isLeft, isRight);
        }
        Debug.Log($"rb.velocity.x: {rb2D.velocity.x}, rb.velocity.y: {rb2D.velocity.y}");
    }
    void MovePlayer(bool left, bool right)
    {
       
        if (left && rb2D.velocity.x > -speedLimit)
        {
            // v_X = -moveMult * Time.fixedDeltaTime; 
            playerSprite.flipX = true; 
            rb2D.AddForce(new Vector2(-moveMult * Time.fixedDeltaTime,0f));
        }
        else if (right && rb2D.velocity.x < speedLimit)
        {
            //v_X = moveMult * Time.fixedDeltaTime;
            playerSprite.flipX = false; 
            rb2D.AddForce(new Vector2(moveMult * Time.fixedDeltaTime, 0f));
        }
        
       /* else
        {
            //v_Y += -moveMult * 0.1f;
        }*/

       // rb2D.velocity = new Vector2(v_X,v_Y);
    }
    void Jump(bool jump)
    {
        if (jump)
        {
            rb2D.AddForce(new Vector2(0f, moveMult * jumpMult * Time.fixedDeltaTime), ForceMode2D.Impulse);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jumppad"))
        {
            isBoing = true; 
           
            Debug.Log("Boing!");
            rb2D.AddForce(new Vector2(0f, moveMult * 5f * Time.deltaTime), ForceMode2D.Impulse); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //v_Y = 0f;
            isBoing = false;
            jumps = maxJumps; 
           
        }
    }
}
