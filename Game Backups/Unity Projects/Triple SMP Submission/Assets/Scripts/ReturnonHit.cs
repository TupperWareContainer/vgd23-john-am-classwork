using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnonHit : MonoBehaviour
{
    public TitleController tc;
    private bool hasReturned = false; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int i = 0; 
        if (collision.collider.CompareTag("Player"))
        {

            while (!hasReturned)
            {
                if (tc.isDone[i] = !false)
                {
                    i++; 
                }
                else
                {
                    tc.isDone[i] = true;
                    hasReturned = true;
                    Debug.Log($"Player has collided with title trigger no. {i}");
                    gameObject.SetActive(false); 
                }
            }
        }
    }
}
