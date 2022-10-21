using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform instPoint;

    private Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
       if(distanceToPlayer() < 10)
       {
            if (canSeePlayer())
            {
                lookAtPlayer();
                shoot(); 
            }
       }  
    }
    private void shoot()
    {
        Instantiate(bulletPrefab, position: instPoint.position, rotation: transform.rotation);
    }
    /*private void calculateOffset()
    {

    }*/
    private void lookAtPlayer()
    {
        Vector2 distance = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
        float dx = distance.x;
        float dy = distance.y;
        float angle =Mathf.Rad2Deg * Mathf.Atan2(dy, dx);
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f)); 
    }
    private float distanceToPlayer()
    {
        Vector2 distanceVector = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
        float dx = distanceVector.x;
        float dy = distanceVector.y;
        float dist = Mathf.Sqrt((dx * dx) + (dy * dy));
        return dist; 

    }
    public bool canSeePlayer()
    {
        Ray2D ray = new Ray2D(transform.position, player.position);
        
        if (Physics2D.Raycast(ray.origin, ray.direction, distanceToPlayer()).collider.tag.Contains("Player"))
        {
            return true; 
        }
        return false; 
    }
}

