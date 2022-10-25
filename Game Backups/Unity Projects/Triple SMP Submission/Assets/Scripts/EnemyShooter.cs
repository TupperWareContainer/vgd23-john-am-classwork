using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public ReturnColliders rC; 
   
    public Transform instPoint;
    public GameObject bulletDirection; 
    private Transform player;
    public float maxDelay = 5f;
    public float maxDistance = 30f; 
    [SerializeField] private float timer;
    private bool hasFired = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = maxDelay; 
    }

    // Update is called once per frame
    void Update()
    {

       if(distanceToPlayer() <= maxDistance)
       {
            lookAtPlayer();
            if (canSeePlayer())
            {
                if (!hasFired)
                {
                    timer = maxDelay;
                    shoot();
                    
                    hasFired = true; 
                }
               
            }
       }
        if (timer <= 0f)
        {
            hasFired = false; 
        }
        if (hasFired)
        {
            timer -= Time.deltaTime;
        }
        Debug.Log($"enemy player value: {player.position}");
        Debug.Log($"distance to player: {distanceToPlayer()}");
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
        float angle =Mathf.Rad2Deg * Mathf.Atan2(dy, dx) +90f;
        Debug.Log($"Enemy Angle: {angle}"); 
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f)); 
    }
    public float distanceToPlayer()
    {
        Vector2 distanceVector = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
        float dx = distanceVector.x;
        float dy = distanceVector.y;
        float dist = Mathf.Sqrt((dx * dx) + (dy * dy));
        return dist; 

    }
    public bool canSeePlayer()
    {

        /*Ray2D ray = new Ray2D(transform.position,transform.forward * distanceToPlayer());
        RaycastHit2D vision = Physics2D.Raycast(ray.origin, bulletDirection.transform.position, distanceToPlayer()*2 );
        Debug.DrawRay(ray.origin, ray.direction * distanceToPlayer()); 
        if(vision != false)
        {
            if (vision.collider.CompareTag("Player"))
            {
                return true;
            }
            
        }
        return false;*/
        if (rC.isCollidingWithPlayer())
        {
            return true; 
        }
        return false; 
    }
    
}

