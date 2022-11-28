using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    [SerializeField] private bool up, down, left, right;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
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
            right = false;
            left = false; 
        }
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            up = true;
            down = false; 
        }
        else if(Input.GetAxisRaw("Vertical") < 0)
        {
            down = true;
            up = false; 
        }
        else
        {
            up = false;
            down = false; 
        }
    }
    private void FixedUpdate()
    {
        MovePlayer(up, down, left, right); 
    }

    private void MovePlayer(bool isUp,bool isDown, bool isLeft, bool isRight)
    {
        float dX = 0f, dY = 0f;
        if (isUp) dY = moveSpeed * Time.fixedDeltaTime;
        if (isDown) dY = -moveSpeed * Time.fixedDeltaTime;
        if (isLeft) dX = -moveSpeed * Time.fixedDeltaTime;
        if (isRight) dX = moveSpeed * Time.fixedDeltaTime;
        Vector2 newV = new Vector2(dX, dY);
        rb.velocity = newV; 
        
    }
}
