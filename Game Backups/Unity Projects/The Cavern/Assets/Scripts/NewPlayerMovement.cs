using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    //public Rigidbody rb;
    private Transform playerTransform;
    //public Transform absoluteTransform; 
    //private int xDir = 0;
    //private int zDir = 0; 
    public float moveMult = 3f;
    public float groundOffset = 0.5f;

    //  public float jumpheight = 15f;   //maybe add jumping in the future 
    // private int maxJumps; 
    // public int jumps = 1; 
    //private float jumpForce;
    private int excludedLayer = ~3;
    private float yVelocity;
    private Vector3 overlapPos;
    private Vector3 playerSize;

    private Collider[] collisions = new Collider[1];
    [SerializeField] private bool isfalling;

    private void Start()
    {
        playerTransform = transform;


    }

    void Update()
    {
        /// casts a box below the player that determines whether it has come into contact with the ground 
        overlapPos = playerTransform.position + Vector3.down * groundOffset;
        playerSize = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isfalling = !Physics.CheckBox(overlapPos, playerSize, playerTransform.rotation, excludedLayer);
        if (Physics.CheckBox(overlapPos, playerSize, playerTransform.rotation, excludedLayer))
        {
            ResetPlayerPos();
            isfalling = false;
        }
        Debug.Log(yVelocity);
        /// preforms a raycast that checks if the player has hit the ground or not 
        /// if the player has hit the ground then reset stored velocity, reset the number of jumps, and tell the rest of the code that the player isnt jumping
        /*if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            isfalling = false;
            //jumps = maxJumps;
            yVelocity = 0f; 
        }
        else
        {
            isfalling = true;
        } */
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate((Vector3.forward * moveMult) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate((Vector3.back * moveMult) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Translate((Vector3.left * moveMult) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Translate((Vector3.right * moveMult) * Time.deltaTime);
        }
        /* if (jumps > 0 && Input.GetKey(KeyCode.Space)){

             transform.Translate((Vector3.up * jumpForce*100f) * Time.deltaTime); 
             jumps--;
             Debug.Log("Boing");
         }  */
        if (isfalling)
        {
            yVelocity += -9.81f * Time.deltaTime;
            transform.Translate(new Vector3(0f, (yVelocity), 0f) * Time.deltaTime);
            Debug.Log("falling");
        }
        else
        {
            yVelocity = 0f;
        }

    }
    private void ResetPlayerPos()
    {
        collisions[0] = Physics.OverlapBox(overlapPos, playerSize, playerTransform.rotation, excludedLayer)[0];
        Vector3 playerPos = transform.position;
        float offset;
        if (collisions[0].GetComponent<BoxCollider>())
        {
            offset = collisions[0].GetComponent<BoxCollider>().size.y;
        }
        else
        {
            offset = 0f;
        }
        Vector3 closestPoint = Physics.ClosestPoint(transform.position, collisions[0], collisions[0].transform.position, transform.rotation);
        playerTransform.position = new Vector3(transform.position.x, closestPoint.y + offset, transform.position.z);
        Debug.Log("snapped");


    }

}
