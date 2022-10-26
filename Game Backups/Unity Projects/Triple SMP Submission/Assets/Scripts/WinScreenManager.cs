using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class WinScreenManager : MonoBehaviour
{
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
}
