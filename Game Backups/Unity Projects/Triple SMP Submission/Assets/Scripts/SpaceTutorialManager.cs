using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SpaceTutorialManager : MonoBehaviour
{

    public Text tutorialText;
    private bool b = false;
    float timer = 0f;
 
    
    private void Start()
    {

        
        tutorialText.gameObject.SetActive(true); 
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            tutorialText.text = "Your Mission: Defend the Space Station";
            b = true;
        }
        if (b)
        {
            timer += Time.deltaTime; 
        }
        if(timer > 2)
        {
            tutorialText.gameObject.SetActive(false);
            gameObject.SetActive(false); 
        }
        
    }
}
