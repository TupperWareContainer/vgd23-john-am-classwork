using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public RigidbodyMovement rigidbodyMovement;
    private Rigidbody2D rb;
    private Vector2 launchAngle;
    public float f_Mult;
    public float maxV = 20; 
    private GameObject aimpos;
    [SerializeField] float timer; 
    private void Awake()
    {
        aimpos = GameObject.Find("Aimpos"); 
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("fire!");
        
       // float d_x = Mathf.Sin(launchAngle * Mathf.Deg2Rad) * f_Mult;
        //float d_y = Mathf.Cos(launchAngle * Mathf.Deg2Rad) * f_Mult;
       // launchAngle = new Vector2(transform.position.x - aimpos.transform.position.x, transform.position.y - aimpos.transform.position.y);
        
        Debug.Log($"transform.forward for {name}: {transform.forward}");
        transform.LookAt(aimpos.transform.position);
        rb.velocity = ApplyVelocity(maxV); 
        Debug.Log($"rb.velocity for {name}: {rb.velocity}");

    }
    private void Update()
    {
        if (rb.velocity.magnitude < maxV)
        {
            rb.velocity += new Vector2(transform.forward.x * Time.deltaTime, transform.forward.y * Time.deltaTime) * 100;   
        }
        else if(rb.velocity.magnitude > maxV)
        {
            rb.velocity -= new Vector2(transform.forward.x * Time.deltaTime, transform.forward.y * Time.deltaTime) * 100;
        }

        timer += Time.deltaTime;
        if(timer > 2)
        {
            Destroy(gameObject); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>())
        {
            collision.gameObject.GetComponent<EnemyMovement>().deathType = 1; /// when a enemy is hit by a bullet, the deathtype is set to normal 
        }
        //else if (!collision.collider.CompareTag("Enemy")) Destroy(gameObject);
        
    }
    private Vector3 ApplyVelocity(float max_Velocity)
    {
        Vector3 v = transform.forward * f_Mult;
        if (v.sqrMagnitude < max_Velocity)
        {
            v += transform.forward * 10;
        }
        else if (v.sqrMagnitude > max_Velocity)
        {
            v -= transform.forward * 10;
        }
        return v; 
    }
}
