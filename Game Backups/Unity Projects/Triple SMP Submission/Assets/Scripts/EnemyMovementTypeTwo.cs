using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTypeTwo : MonoBehaviour
{
    public float moveSpeed;

    public bool isPatrol; 
    
    public ReturnColliders returnColliders;
    public Transform[] patrolRoute;
    public ScoreKeeper sk; 

    private EnemyShooter enemyShooter; 
   [SerializeField] int patrolPt = 0; 
    private EnemyShooter shooterMode;
    private Rigidbody2D rb2d;
    private Transform player;
    public float maxRememberTime = 3f;
    private float rememberTime;
    private int deathType; 
    /**
     * The main idea of this script is that this enemy type (shooter) wants to stay within range of the player, however they can only do so once 
     * they know the player exists and shouldn't just blindly rush towards the player
     */
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyShooter = GetComponent<EnemyShooter>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rememberTime = maxRememberTime;
        if (patrolRoute[1] = null) patrolRoute = new Transform[0]; 
    }
    private void FixedUpdate()
    {
        if (patrolPt >= patrolRoute.Length) patrolPt = 0;
        
        if (enemyShooter.distanceToPlayer() <= enemyShooter.maxDistance)
        {
            rememberTime = maxRememberTime; 
            isPatrol = false; 
            returnColliders.gameObject.SetActive(true);
            patrolPt = 0;
            moveToPlayer(); 

        }
        else if(enemyShooter.distanceToPlayer()> enemyShooter.maxDistance && rememberTime > 0)
        {
            moveToLastPlayerPos(player.position); 
            rememberTime -= Time.fixedDeltaTime;           
        }
        else
        {
            returnColliders.gameObject.SetActive(false); 
            if (patrolRoute.Length > 0) patrol(patrolPt);

        }
        
    }
    private void patrol(int pointInPatrol)
    {
        //take current pos of the enemy and subtract from patrol point 
        Vector3 currentPoint = new Vector3(transform.position.x - patrolRoute[pointInPatrol].position.x, transform.position.y - patrolRoute[pointInPatrol].position.y, 0f);
        float dx = -currentPoint.x;
        
        float dy = -currentPoint.y;

        rb2d.velocity = new Vector2(dx + dx * moveSpeed * Time.fixedDeltaTime, dy+dy * moveSpeed * Time.fixedDeltaTime); 

        Debug.Log($"currentPoint: {currentPoint}");
         
             
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PatrolRoute"))
        {
            patrolPt++;
        }
        if (collision.CompareTag("Bullet"))
        {
            deathType = 3;
       
            Die(collision, deathType);
        }
        else if (collision.CompareTag("Explosion"))
        {
            Debug.Log("Collider with exploder");
            deathType = 2;
            Die(collision, deathType);
        }
        else if (collision.CompareTag("Laser"))
        {
            deathType = 1;
            Die(collision, deathType);
        }
    }
    private void moveToPlayer()
    {
        Vector3 movementVector = new Vector3(transform.position.x - player.position.x, transform.position.y - player.position.y, 0f);
        float dx = -movementVector.x * moveSpeed;
        float dy =-movementVector.y * moveSpeed;
        rb2d.velocity = new Vector2(dx * Time.fixedDeltaTime, dy * Time.fixedDeltaTime);
    }
    private void moveToLastPlayerPos(Vector3 lastKnownPos)
    {
        Vector3 movementVector = new Vector3(transform.position.x - lastKnownPos.x, transform.position.y - lastKnownPos.y, 0f);
        float dx = -movementVector.x * moveSpeed;
        float dy = -movementVector.y * moveSpeed;
        rb2d.velocity = new Vector2(dx * Time.fixedDeltaTime, dy * Time.fixedDeltaTime); 

    }

    public void Die(Collider2D col, int dType)
    {
        GameObject giver = col.gameObject; 
        switch (dType)
        {
            case 1:
                Destroy(giver);
                sk.QueueStyleText("+KILL");
                sk.StyleMeterScore(4);
                Destroy(returnColliders.gameObject);
                Destroy(gameObject); 
                break;
            case 2:
                sk.QueueStyleText("+BOOM");
                sk.StyleMeterScore(4);
                Destroy(returnColliders.gameObject);
                Destroy(gameObject);
                break;
            default:
                Destroy(giver);
                sk.QueueStyleText("+KILL");
                sk.StyleMeterScore(4);
                Destroy(returnColliders.gameObject);
                Destroy(gameObject);
                break; 
        }
    }
}
