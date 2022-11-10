using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int maxHealth = 3;
    private float health;
    private void Start()
    {
        health = maxHealth; 
    }
    private void Update()
    {
        if(health <= 0)
        {
            Die(); 
        }
    }
    public void TakeDamage (int damage)
    {
        health -= damage; 
    }
    private void Die()
    {
        Destroy(gameObject);
    }

}
