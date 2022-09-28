using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public RigidbodyMovement rigidbodyMovement;
    private Rigidbody2D rb;
    private float launchAngle;
    public float f_Mult;
    private GameObject aimpos;
    [SerializeField] float timer; 
    private void Awake()
    {
        aimpos = GameObject.Find("Aimpos"); 
        rb = GetComponent<Rigidbody2D>();
        //launchAngle = rigidbodyMovement.desiredAngle;
        //float d_x = Mathf.Sin(launchAngle * Mathf.Deg2Rad) * f_Mult;
        //float d_y = Mathf.Cos(launchAngle * Mathf.Deg2Rad) * f_Mult;
        transform.LookAt(aimpos.transform);
        rb.velocity = transform.forward.normalized * f_Mult;       
    }
    private void Update()
    {
       
        timer += Time.deltaTime;
        if(timer > 100)
        {
            Destroy(gameObject); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
