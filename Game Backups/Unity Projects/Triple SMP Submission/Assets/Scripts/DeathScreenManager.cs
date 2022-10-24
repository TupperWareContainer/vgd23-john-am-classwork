using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DeathScreenManager : MonoBehaviour
{

    

    public void Quit()
    {
        Debug.Log("quit"); 
        Application.Quit();
        
    }
    public void TryAgain()
    {
        Debug.Log("try again");  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void LoadMenu()
    {
        Debug.Log("load menu");
        SceneManager.LoadScene(0); 
    }
    public void TryAgainFromBeginning()
    {
        Debug.Log("try again from beginning"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
