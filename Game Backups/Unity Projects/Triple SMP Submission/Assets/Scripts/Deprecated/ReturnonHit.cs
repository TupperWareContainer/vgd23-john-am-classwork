using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnonHit : MonoBehaviour
{
    public TitleController tc;
    private bool hasReturned = false;
    int i = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            while (!hasReturned)
            {
                if (tc.isDone[i] = !false)
                {
                    i++;
                    Debug.Log($"i is {i}"); 
                    hasReturned = false; 
                }
                else
                {
                    tc.isDone[i] = true;
                    hasReturned = true;
                    Debug.Log($"Player has collided with title trigger no. {i}");
                    gameObject.SetActive(false);
                }
                if(i >= tc.isDone.Length)
                {
                    i = 0;
                    return; 
                }
               
            }
        }
    }
}
