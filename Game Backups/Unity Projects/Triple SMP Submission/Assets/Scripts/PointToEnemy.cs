using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToEnemy : MonoBehaviour
{
    public Transform arrow;
    private Transform target;
    public Transform player;
    float angle;
    public Vector2 arrowOffset; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            target = collision.transform; 
        }
    }
    
    private void Update()
    {
       
        Point();  
    }
    private void Point()
    {
        
        Vector2 distance = new Vector2(target.position.x - player.position.x, target.position.y - player.position.y);
        angle = (Mathf.Rad2Deg * Mathf.Atan2(distance.y, distance.x)) + 90;
        arrow.transform.position = new Vector3(player.position.x + arrowOffset.x,player.position.y + arrowOffset.y,player.position.z);
       arrow.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
    }
}
