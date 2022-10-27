using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winScreen; 
    private bool isWin;
    private RigidbodyMovement player;
    private Rigidbody2D playerRB; 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyMovement>(); 
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    public void LoadNext()
    {
        Debug.Log("Loading next scene"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void Quit()
    {
        Debug.Log("Goodbye! :)"); 
        Application.Quit(); 
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    /// <summary>
    /// determines whether or not the player wins, and sets the win ui to active 
    /// </summary>
    public void SetWinActive()
    {
        isWin = true; 
    }
    
    /// <summary>
   /// determines whether or not the player wins, and sets the win ui to active depending on user choice 
   /// </summary>
   /// <param name="active"></param> determines whether the win screen is active 
    public void SetWinActive(bool active)
    {
        isWin = active; 
    }
    private void Update()
    {
        if (isWin)
        {
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll; 
            player.enabled = false;
            winScreen.SetActive(true); 
          
            
        }
    }
}
