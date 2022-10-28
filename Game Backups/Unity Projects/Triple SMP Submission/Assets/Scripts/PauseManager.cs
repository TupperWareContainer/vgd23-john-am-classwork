using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseManager : MonoBehaviour
{

   
    public GameObject pauseMenu; 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Pause();
                Debug.Log("Pressed pause");
            }
            else UnPause(); 
        }
       
    }
    public void UnPause()
    {
        Debug.Log("unpause"); 
        Time.timeScale = 1;
        pauseMenu.SetActive(false);  
    }
    public void Quit()
    {
        Application.Quit(); 
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("loading menu"); 
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    public void TryFromBeginning()
    {
        SceneManager.LoadScene(0);
    }
    private void Pause()
    {
        Debug.Log("pause");
        Time.timeScale = 0;
        pauseMenu.SetActive(true); 
    }

}
