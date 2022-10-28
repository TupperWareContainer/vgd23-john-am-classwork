using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{
    public GameObject creditText;
    public GameObject creditsButton;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject exitCreditsButton; 
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void Quit()
    {
        Application.Quit(); 
    }
    public void Credits()
    {
        creditText.SetActive(true);
        exitCreditsButton.SetActive(true); 
        creditsButton.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
    }
    public void ExitCredits()
    {
        creditText.SetActive(false);
        exitCreditsButton.SetActive(false);
        creditsButton.SetActive(true);
        playButton.SetActive(true);
        quitButton.SetActive(true);
    }
}
