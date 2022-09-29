using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    public float moveMult;
    public ScoreKeeper sk;
    // Start is called before the first frame update
    private void Awake()
    {
        int num = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
       //ameObject[] scorekeepers;
        num = enemies.Length;
        name = $"Enemy {num}"; 
        

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log($"Distance to Enemy: {Vector2.Distance(target.position, transform.position)}");
        if (Vector2.Distance(target.position,transform.position) < 20) {
            pathFinding();
        }
    }
    public void pathFinding()
    {
        float mMod = Vector2.Distance(target.position, transform.position)/10; 
        Vector2 distance = new Vector2(target.position.x-transform.position.x,target.position.y - transform.position.y);
        Debug.Log(distance);

        rb.velocity = distance.normalized * moveMult * mMod * Time.fixedDeltaTime; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            Debug.Log("DEAD");
            //sk.ogScore = sk.score;
            sk.score += 1;
            sk.QueueStyleText("+ENEMY DOWN"); 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}