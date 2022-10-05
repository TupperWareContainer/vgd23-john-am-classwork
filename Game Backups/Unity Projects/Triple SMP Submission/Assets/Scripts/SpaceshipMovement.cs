using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private bool isUp, isDown, isLeft, isRight = false;
    public float shipForce = 3f;
    public GameObject pointer;
     
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isDown = false; 
            isUp = true; 
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            isUp = false;
            isDown = true; 
        }
        else
        {
            isUp = false;
            isDown = false; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
            isLeft = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isRight = false;
            isLeft = true; 
        }
        else
        {
            isLeft = false;
            isRight = false; 
        }
        RotateObj(); 
        
    }
    private void FixedUpdate()
    {
        Move(isUp, isDown, isLeft, isRight); 
    }
    private void Move(bool up, bool down, bool left, bool right)
    {
        if (up)
        {
            //rb2D.AddForce(new Vector2(0f, shipForce * Time.fixedDeltaTime), ForceMode2D.Impulse); 
           // rb2D.AddForce( transform.right * shipForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            Debug.Log(transform.forward * shipForce *Time.fixedDeltaTime);
            rb2D.AddRelativeForce(new Vector2(0f,shipForce* Time.deltaTime), ForceMode2D.Impulse);
        }
        else if (down)
        {
            // rb2D.AddForce(new Vector2(0f, -shipForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
            //rb2D.AddForce( transform.right * -shipForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            rb2D.AddRelativeForce(new Vector2(0f, -shipForce * 100 * Time.deltaTime),ForceMode2D.Impulse);
        }
        if (right)
        {
            rb2D.AddRelativeForce(new Vector2(shipForce * Time.deltaTime,0f),ForceMode2D.Impulse); 
        }
        else if (left)
        {
            rb2D.AddRelativeForce(new Vector2(-shipForce * Time.deltaTime, 0f), ForceMode2D.Impulse);
        }
    }
    private void RotateObj()
    {
        float angle;
        Vector2 distance = new Vector2(pointer.transform.position.x - gameObject.transform.position.x, pointer.transform.position.y - gameObject.transform.position.y);
        float dX = distance.x;
        float dY = distance.y;
        angle = Mathf.Rad2Deg * Mathf.Atan2(dY,dX) + 270;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
    }
}

