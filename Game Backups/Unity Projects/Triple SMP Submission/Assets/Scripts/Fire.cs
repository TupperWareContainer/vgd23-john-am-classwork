using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public RigidbodyMovement rigidbodyMovement;
    private Rigidbody2D rb;
    private Vector2 launchAngle;
    public float f_Mult;
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
        rb.velocity = transform.forward * f_Mult;
       
    }
    private void Update()
    {

        timer += Time.deltaTime;
        if(timer > 2)
        {
            Destroy(gameObject); 
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }      */ 
}
