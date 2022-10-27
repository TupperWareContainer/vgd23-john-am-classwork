using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWinOnHit : MonoBehaviour
{
    public WinScreenManager wSM; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wSM.SetWinActive(); 
        }
    }
}
