using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float launchVelocity = 10f;
    private Transform player; 
    private Rigidbody2D rb; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    private void lookAtPlayer()
    {
        Vector2 distance = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
        float dx = distance.x;
        float dy = distance.y;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dy, dx);
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
    }
    void applyVelocity()
    {

    }
}
