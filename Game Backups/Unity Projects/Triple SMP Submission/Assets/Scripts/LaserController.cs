using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public bool isActive = false;
    //public Transform p1;
   // public Transform p2;
   
  
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyMovement>().deathType = 1; /// when a enemy is hit by a bullet, the deathtype is set to normal 
            }
        }
    } 
}
