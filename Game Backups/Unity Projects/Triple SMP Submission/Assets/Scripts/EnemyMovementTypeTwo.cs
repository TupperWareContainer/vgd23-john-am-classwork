using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTypeTwo : MonoBehaviour
{
    public float moveSpeed;
    public float patrolThreshold;
    private Vector2 pT; 
    public ReturnColliders returnColliders;
    public Transform[] patrolRoute;
    int patrolPt = 0; 
    private EnemyShooter shooterMode;
    /**
     * The main idea of this script is that this enemy type (shooter) wants to stay within range of the player, however they can only do so once 
     * they know the player exists and shouldn't just blindly rush towards the player
     */
    private void Start()
    {
        pT = new Vector2(patrolThreshold, patrolThreshold); 
    }
    private void FixedUpdate()
    {
        patrol(patrolPt);
        if(transform.position == patrolRoute[patrolPt].position )
        {
            patrolPt++; 
        }
    }
    private void patrol(int pointInPatrol)
    {
        //take current pos of the enemy and subtract from patrol point 
        Vector3 currentPoint = new Vector3(patrolRoute[patrolPt].position.x - transform.position.x,patrolRoute[patrolPt].position.y - transform.position.y, patrolRoute[patrolPt].position.z); 
        transform.Translate(currentPoint); 
       
    }
}
