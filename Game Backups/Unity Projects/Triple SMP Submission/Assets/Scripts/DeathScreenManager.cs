using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DeathScreenManager : MonoBehaviour
{

    

    public void Quit()
    {
        Application.Quit();
    }
    public void TryAgain()
    {
         
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void LoadMenu()
    {
        SceneManager.LoadScene(0); 
    }
    public void TryAgainFromBeginning()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
