using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    public float moveMult = 3f;
    public Rigidbody2D rb2D;
    private bool isLeft, isRight, isJump = false;
    public float v_X;
    public float v_Y;
    bool isBoing; 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; /// the timescale is set to 1 whenever the level is loaded as a consequence of the player possibly reloading the level from another where the timescale is set to zero
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
        

    }
    private void FixedUpdate()
    {
        if (!isBoing)
        {
            MovePlayer(isLeft, isRight, isJump);
        }
    }
    void MovePlayer(bool left, bool right, bool jump)
    {
       
        if (left)
        {
            // v_X = -moveMult * Time.fixedDeltaTime; 
            rb2D.AddForce(new Vector2(-moveMult * Time.fixedDeltaTime,0f));
        }
        else if (right)
        {
            //v_X = moveMult * Time.fixedDeltaTime;
            rb2D.AddForce(new Vector2(moveMult * Time.fixedDeltaTime, 0f));
        }
        else
        {
            v_X = 0; 
        }
        if (jump)
        {
            rb2D.AddForce(new Vector2(0f,moveMult),ForceMode2D.Impulse);
            
        }
        else
        {
            //v_Y += -moveMult * 0.1f;
        }
        Debug.Log($"Vx: {v_X} Vy: {v_Y}"); 

       // rb2D.velocity = new Vector2(v_X,v_Y);
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
            v_Y = 0f;
            isBoing = false;
           
        }
    }
}
