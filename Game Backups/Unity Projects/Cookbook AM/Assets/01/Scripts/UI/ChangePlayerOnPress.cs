using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ChangePlayerOnPress : MonoBehaviour
{
    public GameObject player;
    private int playerHealth;
    public int maxHealth = 10;
    double hPercent;
    public TextMeshPro text;  
    private void Start()
    {
        playerHealth = maxHealth;
        text.SetText(playerHealth.ToString());
    }
    public void TakeDamage()
    {

        playerHealth--;
        hPercent = (playerHealth / (double)maxHealth);
        if (hPercent >= .75)
        {
            player.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (hPercent >= .5)
        {
            player.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (hPercent >= .25)
        {
            player.GetComponent<SpriteRenderer>().color = Color.red;
        }
        text.SetText(playerHealth.ToString()); 
       
    }
    public void setHealth(int newHealth)
    {
        playerHealth = newHealth; 
    }
    public int getHealth()
    {
        return playerHealth; 
    }
    private void Update()
    {
        if(getHealth() <= 0)
        {
            setHealth(maxHealth); 
        }
       
        Debug.Log($"Player Health: {getHealth()}");
        Debug.Log($"HPercent: {hPercent}"); 
      
    }


}
