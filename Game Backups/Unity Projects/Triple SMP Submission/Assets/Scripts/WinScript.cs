using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
         
        if (collision.collider.CompareTag("Player"))
        {
            Time.timeScale = 0;
            winScreen.SetActive(true); 
            

        }
    }
}
