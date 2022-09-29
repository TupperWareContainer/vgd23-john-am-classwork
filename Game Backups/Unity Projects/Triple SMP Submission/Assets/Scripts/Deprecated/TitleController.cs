using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public Text[] titleMessages = new Text[3];
    public bool[] isDone = new bool[3] { false, false, false}; 
    private bool isTSFinished = false;
    private int arrayScanner = 0; 
    public GameObject player; 
    private void Update()
    {
        if (!isTSFinished)
        {
            checkTriggers();
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
    void checkTriggers()
    {

        if (isDone[arrayScanner % isDone.Length] == true)
        {
           
            CheckSequence(arrayScanner);
        }
        else
        {
            arrayScanner++;
            Debug.Log($"arrayScanner {arrayScanner}");
        }
        if (isDone[1] && isDone[2] && isDone[0])
        {
            isTSFinished = true; 
        }
        if (arrayScanner >= isDone.Length)
        {
            arrayScanner = 0;
        }

    }
}
