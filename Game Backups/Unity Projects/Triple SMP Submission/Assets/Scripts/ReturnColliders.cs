using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnColliders : MonoBehaviour
{
    private bool isCollide = false;
    public Transform parent; 
    
    /**
     * Returns whether or not the player is within the check radius 
     */
    public bool isCollidingWithPlayer()
    {
        return isCollide; 
    }
    private void Update()
    {
        transform.position = parent.position;
        if (parent.gameObject == null)
        {
            Destroy(gameObject); 
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollide = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isCollide = false; 
    }
}
