using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveIncrement = 15f;
    public float jumpMult = 2f;
    public float desiredHeight = 10f;
    [SerializeField] bool isLeft = false;
    [SerializeField] bool isRight = false;
    [SerializeField] bool isUp = false;
    [SerializeField] bool isGrounded;
    private Vector2 offset = new Vector2(0f, -1);
    private float timer;
    public LayerMask layermask;

    float vX;
    float vY;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            isRight = false; 
            isLeft = true; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isLeft = false; 
            isRight = true; 
        }

        else
        {
            isLeft = false;
            isRight = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            isUp = true;
            Debug.Log("jump"); 
        }
        else
        {
            isUp = false;
        }

    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.BoxCast(rb.transform.position, transform.lossyScale, 0f,Vector2.down,0.2f,layermask );
        Debug.DrawLine(rb.transform.position, rb.transform.position + new Vector3(0f,-1f,0f),Color.green); 
        Move(isLeft, isRight, isUp);
        if (!isGrounded)
        {
            //timer += Time.fixedDeltaTime;
            vY  -= 3f * Time.fixedDeltaTime; 
        }
        else 
        {
            vY = 0; 
        }
        
    }
    private void Move(bool left, bool right, bool up)
    {
        Vector2 output = new Vector2();
        
        if (up && isGrounded)
        {
            //rb.AddForce(Vector2.up * jumpMult * Time.fixedDeltaTime ,ForceMode2D.Impulse);
           // Debug.Log($"added {Vector2.up * jumpMult * Time.fixedDeltaTime} units of force"); 
            vY = moveIncrement * jumpMult;
           // isGrounded = false; 
        }
        
        if (right)
        {
            vX= moveIncrement * Time.fixedDeltaTime;
            
        }
        else if (left)
        {
            vX = -moveIncrement * Time.fixedDeltaTime; 
        }
        else
        {
            vX = 0f; 
        }
        output = new Vector2(vX, vY); 
        rb.velocity = output; 
        
    }
}
