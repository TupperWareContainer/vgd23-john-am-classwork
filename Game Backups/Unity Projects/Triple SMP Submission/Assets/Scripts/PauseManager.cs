using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseManager : MonoBehaviour
{

    private bool isPaused = false;
    public GameObject pauseMenu; 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused; 
        }
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true); 
        }
        else
        {
            UnPause(); 
        }
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false); 
        isPaused = false; 
    }
    public void Quit()
    {
        Application.Quit(); 
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

}
