using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    public float moveMult = 3f;
    public Rigidbody2D rb2D;
    private bool isLeft, isRight, isJump = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            isLeft = false;
            isRight = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isRight = false;
            isLeft = true; 
        }
        else
        {
            isLeft = false;
            isRight = false; 
        }
        
    }
    private void FixedUpdate()
    {
        MovePlayer(isLeft,isRight,isJump);
    }
    void MovePlayer(bool left, bool right, bool jump)
    {
        float v_X;
        float v_Y;
        if (left)
        {
            v_X = -moveMult * Time.fixedDeltaTime; 
        }
        if (right)
        {
            v_X = moveMult * Time.fixedDeltaTime;
        }
    }
}
