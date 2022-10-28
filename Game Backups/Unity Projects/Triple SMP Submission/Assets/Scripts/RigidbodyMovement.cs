using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveIncrement = 15f;
    public float jumpMult = 2f;
    public float desiredHeight = 10f;
    public float desiredAngle;
    public float angleOffset; 
    [SerializeField] bool isLeft;
    [SerializeField] bool isRight;
    [SerializeField] bool isUp;
    [SerializeField] bool isDown;
    public bool canFire = true;
    public bool canSlow = false; 
    //[SerializeField] bool isGrounded;
    [SerializeField] bool fire ;
    public Aim aimS;
    private Vector2 mousePos;
   
   // private Vector2 offset = new Vector2(0f, -1);
    //private float timer;
    //public LayerMask layermask;
    public Transform inst_point;
    public GameObject proj;
    public GameObject arm;
    public GameObject headForward;
    public GameObject headRight;

    float vX;
    float vY;

    
    // Update is called once per frame
    void Update()
    {
        mousePos = aimS.mousePos;
        if (Input.GetKey(KeyCode.A))
        {
            isRight = false; 
            isLeft = true;
            Debug.Log("Left"); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isLeft = false; 
            isRight = true;
            Debug.Log("right");
        }

        else
        {
            isLeft = false;
            isRight = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            isUp = true;
            isDown = false; 
            Debug.Log("forward"); 
        }
         if (Input.GetKey(KeyCode.S))
        {
            isUp = false;
            isDown = true;
            Debug.Log("backwards");

        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            isUp = false;
            isDown = false; 
        }
        if (Input.GetKey(KeyCode.R))
        {
            rb.position = new Vector2(0f, 0f);
            rb.velocity = new Vector2(0f, 0f); 
        }
        if (Input.GetKeyDown(KeyCode.Space) && Vector2.Distance(transform.position,mousePos) >= 2 && canFire)
        {
            fire = true; 
        }
        else
        {
            fire = false; 
        }
        
        Punt(fire, proj, desiredAngle, inst_point);
        Debug.Log(Vector2.Distance(transform.position, mousePos));
        Look(aimS.gameObject.transform); 
    }
    private void FixedUpdate()
    {
       // isGrounded = Physics2D.BoxCast(rb.transform.position, transform.lossyScale, 0f,Vector2.down,0.2f,layermask );
        Debug.DrawLine(rb.transform.position, rb.transform.position + new Vector3(0f,-1f,0f),Color.green); 
        Move(isLeft, isRight, isUp,isDown);
        
       /* if (!isGrounded)
        {
            //timer += Time.fixedDeltaTime;
            vY  -= 3f * Time.fixedDeltaTime; 
        }
        else 
        {
            vY = 0; 
        }*/ 
        
    }
    private void Move(bool left, bool right, bool up,bool down)
    {
        Vector2 output = new Vector2();

        /* if (up && isGrounded)
         {
             //rb.AddForce(Vector2.up * jumpMult * Time.fixedDeltaTime ,ForceMode2D.Impulse);
            // Debug.Log($"added {Vector2.up * jumpMult * Time.fixedDeltaTime} units of force"); 
             vY = moveIncrement * jumpMult;
            // isGrounded = false; 
         }
         */
        if (up)
        {
            vY = moveIncrement * Time.fixedDeltaTime; 
        }
        else if (down)
        {
            vY = -moveIncrement * Time.fixedDeltaTime; 
        }
        else
        {
            vY = 0f; 
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
        if (Input.GetKey(KeyCode.Q) && canSlow)
        {
            SlowTime(true, 0.5f);
            Debug.Log("Slow Motion"); 
        }
        else
        {
            Debug.Log("not slow motion"); 
            SlowTime(false); 
        }

        output = new Vector2(vX, vY); 
        rb.velocity = output; 
        
    }
    private void Punt(bool isFire,GameObject inst, float angle,Transform p)
    {
        if (isFire)
        {
          
           
            GameObject.Instantiate(inst, position: p.position,inst_point.localRotation);
        }
    }
    private void Look(Transform lookPosition)
    {
        Vector2 lp = new Vector2(lookPosition.position.x - transform.position.x, lookPosition.position.y - transform.position.y);
        float dX = lp.x; 
        float dY = lp.y; 
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dY, dX);
        if (!canFire)
        {
            transform.rotation = Quaternion.AngleAxis(angle- angleOffset, new Vector3(0f, 0f, 1f));
            headForward.SetActive(true);
            headRight.SetActive(false); 
        }
        else
        {
            arm.SetActive(true); 
            transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
            headForward.SetActive(false);
            headRight.SetActive(true);
        }
    }
   /// <summary>
   /// Halfs the timescale 
   /// </summary>
   /// <param name="isSlowing"></param> true = slowtime, false = normaltime
    private void SlowTime(bool isSlowing)
    {
        if (isSlowing) Time.timeScale = 0.5f;
        else Time.timeScale = 1f; 
    }
    /// <summary>
    /// sets the timescale to a wanted floating point number 
    /// </summary>
    /// <param name="isSlowing"></param>    true = slowtime, false = normaltime
    /// <param name="newTimeScale"></param> Timescale to be set, 1 = normal scale, 0 = game is frozen; 
    private void SlowTime(bool isSlowing, float newTimeScale)
    {
        if (isSlowing) Time.timeScale = newTimeScale;

        else Time.timeScale = 1f; 
    }
    
}
