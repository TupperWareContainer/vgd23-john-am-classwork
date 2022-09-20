using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbMovement : MonoBehaviour
{
    public Rigidbody rb;
    private Transform rbTransform; 

    public float speed = 3f;
    private float moveSpeedX = 0f;
    private float moveSpeedZ = 0f;
    private bool left, right, forward, back = false;
    // Start is called before the first frame update
    void Start()
    {
        rbTransform = rb.transform;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Forward");
            back = false;
            forward = true;
                       
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("back");
            forward = false;
            back = true; 
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("right"); 
            left = true; 
            right = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("left"); 
            right = true;
            left = false; 
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            forward = false; 
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            back = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            right = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            left = false;
        }

        /*forward = false;
        back = false;
        right = false;
        left = false; */
    }
    private void FixedUpdate()
    {
        Move(left, right, forward, back); 
    }
    private void Move (bool isLeft, bool isRight, bool isForward, bool isBack)
    {
       
        
        if (isForward)
        {
            moveSpeedZ = speed;
            Debug.Log("Move F");
        
          
        }
        else if (isBack )
        {
            moveSpeedZ = -speed; 
        }
        if(isRight )
        {
            moveSpeedX = speed; 
        }
        else if (isLeft)
        {
            moveSpeedX = -speed; 
        }
        Vector3 output = new Vector3(moveSpeedX * Time.deltaTime, 0f, moveSpeedZ * Time.deltaTime);
        rbTransform.Translate(output); 
        Debug.Log($"x: {moveSpeedX * Time.fixedDeltaTime}, z: {moveSpeedZ * Time.fixedDeltaTime}");
        Debug.Log(output); 
        
    }
}
