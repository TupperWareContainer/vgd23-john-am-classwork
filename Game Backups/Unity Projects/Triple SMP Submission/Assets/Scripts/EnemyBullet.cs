using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 forward;
    private GameObject player; 
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 

        rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.AngleAxis(getAngle(), new Vector3(0f, 0f, 1f));
        forward = new Vector2(transform.up.x * speed, transform.up.y * speed);
        Debug.Log($"bulletforward {forward}");
        rb.velocity = forward; 
        

    }
    
    public float getAngle()
    {
        Vector2 distance = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
        float dx = distance.x;
        float dy = distance.y;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dy, dx) + 90f;
        return angle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<HealthbarController>().DamagePlayer(1);
            Debug.Log("Player Hit");
            Destroy(gameObject);
        }
        if (!collision.CompareTag("IgnoreBullet"))
        {
            Destroy(gameObject);
        }
    }
}
