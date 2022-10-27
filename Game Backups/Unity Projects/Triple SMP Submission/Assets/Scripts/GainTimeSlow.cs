using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GainTimeSlow : MonoBehaviour
{
    public RigidbodyMovement player;
    public Text instructions;
    private GameObject textObj;

    private void Start()
    {
        textObj = instructions.gameObject; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<RigidbodyMovement>(); 

        }
    }
    private void CycleText()
    {
        textObj.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {

        }
        string str_1 = "Press Q to slow time.\n This ability lasts for a limited amount of time, so use it wisely!"; 
        
    }
}
