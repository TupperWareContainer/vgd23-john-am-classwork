using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private bool isUp, isDown, isLeft, isRight,fire = false;
    public float shipForce = 3f;
    public GameObject pointer;
    public float laserRange = 10f;
    public GameObject lasorigin;
    private AudioSource tSound;
    private bool isPlayingAudio = false; 
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tSound = GetComponent<AudioSource>(); 
       
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
        if (Input.GetKey(KeyCode.Space))
        {
            fire = true; 
        }
        else
        {
            fire = false; 
        }
        RotateObj(); 
        if(rb2D.velocity != Vector2.zero && !isPlayingAudio && (isLeft || isRight || isUp || isDown))
        {
            tSound.Play();
            isPlayingAudio = true; 
        }
        else if (!tSound.isPlaying)
        {
            isPlayingAudio = false;
            tSound.Stop();
        }
        else if(!isLeft && !isRight && !isUp && !isDown)
        {
            tSound.Stop();
            isPlayingAudio = false; 
        }
        
    }
    private void FixedUpdate()
    {
        Move(isUp, isDown, isLeft, isRight);
        FireLaser(fire);
       
    }
    private void Move(bool up, bool down, bool left, bool right)
    {
        if (up)
        {
            rb2D.AddForce(new Vector2(0f, shipForce * Time.fixedDeltaTime), ForceMode2D.Impulse); 
           // rb2D.AddForce( transform.right * shipForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            Debug.Log(transform.forward * shipForce *Time.fixedDeltaTime);
            //rb2D.AddRelativeForce(new Vector2(0f,shipForce* Time.deltaTime), ForceMode2D.Impulse);
        }
        else if (down)
        {
             rb2D.AddForce(new Vector2(0f, -shipForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
            //rb2D.AddForce( transform.right * -shipForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            //rb2D.AddRelativeForce(new Vector2(0f, -shipForce * Time.deltaTime),ForceMode2D.Impulse);
        }
        if (right)
        {
            rb2D.AddForce(new Vector2( shipForce * Time.fixedDeltaTime,0f), ForceMode2D.Impulse);
            //rb2D.AddRelativeForce(new Vector2(shipForce * Time.deltaTime,0f),ForceMode2D.Impulse); 
        }
        else if (left)
        {
            rb2D.AddForce(new Vector2(-shipForce * Time.fixedDeltaTime, 0f), ForceMode2D.Impulse);
           // rb2D.AddRelativeForce(new Vector2(-shipForce * Time.deltaTime, 0f), ForceMode2D.Impulse);
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
    private void FireLaser(bool isFire)
    {
        if (isFire)
        {
            /* Debug.Log("Pew");
             Ray2D ray = new Ray2D(lasorigin.position, pointer.transform.position);
             Debug.DrawRay(ray.origin, ray.direction ,Color.red);
             RaycastHit2D hit = Physics2D.Raycast(origin: ray.origin, direction: ray.direction, laserRange);
             Debug.Log($"raycast hit: {hit.collider.name}"); 
             if (hit.collider.CompareTag("Enemy"))
             {
                 hit.collider.gameObject.GetComponent<EnemyMovement>().Die(gameObject.GetComponent<Collider2D>(), 1);

             }*/
            lasorigin.SetActive(true);
            lasorigin.GetComponent<LaserController>().isActive = true; 


        }
        else {
            lasorigin.GetComponent<LaserController>().isActive = false; 
            lasorigin.SetActive(false); 
        }
    }
}

