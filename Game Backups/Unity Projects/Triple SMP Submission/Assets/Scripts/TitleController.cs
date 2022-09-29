using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public Text[] titleMessages = new Text[5];
    public bool[] isDone = new bool[5] { false, false, false, false, false }; 
    private bool isTSFinished = false;
    private int arrayScanner = 0; 
    public GameObject player; 
    private void Update()
    {

        while (!isTSFinished)
        {
            if (isDone[arrayScanner] = true)
            {
                CheckSequence(arrayScanner); 
            }
            else
            {
                arrayScanner++; 
            }
            if(isDone[1] && isDone[2] && isDone[3] && isDone[4] && isDone[0])
            {
                isTSFinished = true; 
            }
        }
    }
    void CheckSequence(int a)
    {
       if(a > 0)
        {
            titleMessages[a-1].gameObject.SetActive(false);
            titleMessages[a].gameObject.SetActive(true);
        }
        else
        {
            titleMessages[a].gameObject.SetActive(true); 
        }
        
    }
}
