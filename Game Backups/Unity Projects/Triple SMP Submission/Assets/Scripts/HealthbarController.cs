using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    public GameObject[] Healthbar = new GameObject[3];
    public GameObject DeathScreen; 
    public int playerHeath = 3;
    private int maxHealth;
    public float invTime = 3f;
    private float maxInvTime; 
    private bool isDamaged = false; 
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerHeath;
        maxInvTime = invTime;
        Time.timeScale = 1; /// the timescale is set to 1 whenever the level is loaded as to avoid the player being frozen on reloading the game 
    }

    // Update is called once per frame
    void Update()
    {
       
        UpdateHealth();
        if (isDamaged && invTime <=0) ///if the player runs out of invincibility frames, then they no longer count as damaged and the timer is reset. 
        {
            isDamaged = false;
            invTime = maxInvTime; 
        }
        else if(isDamaged && invTime > 0) /// if the player is damaged and they still have invincibility frames, subtract time from the invincibility timer
        {
            invTime -= Time.deltaTime; 
        }
    }
    public void DamagePlayer(int damage)
    {
        if (!isDamaged)
        {
            playerHeath -= damage;
            isDamaged = true;
        }
        return; 
    }
    private void Die()
    {
        DeathScreen.SetActive(true);
        Time.timeScale = 0f;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition; 
        return; 
    }
    private void UpdateHealth()
    {
        switch (playerHeath)
        {
            case 0:
                Healthbar[0].SetActive(false);
                Healthbar[1].SetActive(false);
                Healthbar[2].SetActive(false);
                Die();
                break; 
            case 1:
                Healthbar[0].SetActive(true);
                Healthbar[1].SetActive(false);
                Healthbar[2].SetActive(false);
                break;
            case 2:
                Healthbar[0].SetActive(true);
                Healthbar[1].SetActive(true); 
                Healthbar[2].SetActive(false);
                break;
            case 3:
                Healthbar[0].SetActive(true);
                Healthbar[1].SetActive(true);
                Healthbar[2].SetActive(true);
                break; 

        }
    }
}
