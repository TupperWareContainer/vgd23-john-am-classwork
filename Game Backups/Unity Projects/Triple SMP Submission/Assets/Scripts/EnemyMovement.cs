using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private HealthbarController playerhealth; 
    private Rigidbody2D rb;

    public bool isSpace; 
    public float moveMult;
    public ScoreKeeper sk;
    public OpenDoor s_Door;
    public PointToEnemy ptEnemy; 
    public GameObject explosionPrefab;
    public int deathType; 
    /*
     * This is supposed to be a enemy controller script that can be expanded to fit multiple enemy types, it can pathfind towards the player and be killed if the player shoots them  
     */
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
        playerhealth = target.gameObject.GetComponent<HealthbarController>();
        //sk.score++; 
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log($"Distance to Enemy: {Vector2.Distance(target.position, transform.position)}");
        if (!isSpace)
        {
            if (Vector2.Distance(target.position, transform.position) < 20)
            {
                pathFinding();
            }
        }
        else
        {
            if (Vector2.Distance(target.position, transform.position) < 100)
            {
                pathFinding();
            }
        }
    }
    public void pathFinding()
    {
        float mMod = Vector2.Distance(target.position, transform.position)/10; 
        Vector2 distance = new Vector2(target.position.x-transform.position.x,target.position.y - transform.position.y);
        Debug.Log(distance);
        RotateObj(); 

        rb.velocity = distance.normalized * moveMult * mMod * Time.fixedDeltaTime; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerhealth.DamagePlayer(1); 
        }
    }
    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation); 
    }
    public void Die(Collider2D col,int dType)
    {
       

            Debug.Log("DEAD");
            //sk.ogScore = sk.score;
            sk.score--;
            // sk.finalscore += 3; 
            if (!isSpace)
            {
                s_Door.enemies--;
            }
            /*
             * DEATHTYPE RULES:
             * 1 = NORMAL
             * 2 = EXPLODED
             * 
             */
            switch (dType)
            {
                case 1:
                    sk.QueueStyleText("+KILL");
                    sk.StyleMeterScore(4);
                    Explode();
                    //Destroy(col.gameObject);
                    Destroy(gameObject);
                    Debug.Log("Normal Death"); 
                    break;

                case 2:
                    sk.QueueStyleText("+BOOM");
                    ptEnemy.updateDistances();
                    sk.StyleMeterScore(3);
                    Explode();
                    //Destroy(col.gameObject);
                    Destroy(gameObject);
                    break;
            case 3:
                sk.QueueStyleText("+KILL");
                sk.StyleMeterScore(4);
                ptEnemy.updateDistances(); 
                Destroy(gameObject);
                Destroy(col.gameObject); 
                Debug.Log("Normal Death w/o Explosion");
                break; 
            default:
                    sk.QueueStyleText("+KILL");
                    sk.StyleMeterScore(4);
                    Explode();
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                    break;

            }
        
    }
    private void RotateObj()
    {
        float angle;
        Vector2 distance = new Vector2(target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
        float dX = distance.x;
        float dY = distance.y;
        angle = Mathf.Rad2Deg * Mathf.Atan2(dY, dX) + 180;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
    }

}
