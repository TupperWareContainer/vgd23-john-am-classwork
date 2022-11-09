using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveMult = 3f;
    private bool isClimbing; 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){

            if (isClimbing)
            {
                
                rb.MovePosition(rb.position + transform.up * Time.deltaTime * moveMult*3);
                //isMoving = false; 
            }
            else
            {
                rb.MovePosition(rb.position + transform.forward * Time.deltaTime * moveMult);
            } 
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            rb.MovePosition(rb.position - transform.right * Time.deltaTime * moveMult);
            //isMoving = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
           
            rb.MovePosition(rb.position + transform.right * Time.deltaTime * moveMult);
           
        }
        if (Input.GetKey(KeyCode.S))
        {

            if (isClimbing)
            {
                rb.MovePosition(rb.position  - transform.up * Time.deltaTime * moveMult*3);

            }
            else
            {
                rb.MovePosition(rb.position - transform.forward * Time.deltaTime * moveMult);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Climbable")
        {
            isClimbing = true;
            rb.isKinematic = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isClimbing = false;
        rb.isKinematic = false; 
    }
}
