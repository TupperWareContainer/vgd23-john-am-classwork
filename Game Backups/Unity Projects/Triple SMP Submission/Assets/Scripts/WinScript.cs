using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;
    public Text score;
    private void Update()
    {
        if (score.text.Contains("Enemies Left: 0"))
        {
            
            winScreen.SetActive(true);
        }
    }
}
