using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToEnemy : MonoBehaviour
{
    public Transform arrow;
    private Transform target;
    public Transform player;
    //public float circleCastRadius = 100; 
    float angle;
    public Vector2 arrowOffset;
    private RaycastHit2D hit;
    private Transform[] enemyPositions = new Transform[5]; 
    //private Transform[] enemies = new Transform[10];
    //private float[] distances = new float[10];
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            target = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        Point(); 
    }



    private void Update()
    {
        arrow.transform.position = player.transform.position; 
        Point(); 
       
    }
    private void Point()
    {
        
        Vector2 distance = new Vector2(target.position.x - player.position.x, target.position.y - player.position.y);
        float dist = Mathf.Sqrt((distance.x * distance.x) + (distance.y * distance.y)); 
        angle = (Mathf.Rad2Deg * Mathf.Atan2(distance.y, distance.x)) + 270;
        arrow.transform.position = new Vector3(player.position.x + arrowOffset.x,player.position.y + arrowOffset.y,player.position.z);
       arrow.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));

        if (dist > GetComponent<CircleCollider2D>().radius)
        {
            hit = Physics2D.CircleCast(player.position, (dist - (dist - GetComponent<CircleCollider2D>().radius * 3)), Vector2.zero, 0f);
            if (hit)
            {
                //CheckDistance(hit); 
                if (hit.transform.CompareTag("Enemy"))
                {
                    target = hit.transform;
                    Point();
                }
            }
        }
    }
    
   
}
