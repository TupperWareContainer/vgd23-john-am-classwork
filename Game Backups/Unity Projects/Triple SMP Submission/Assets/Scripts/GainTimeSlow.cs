using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GainTimeSlow : MonoBehaviour
{
    public RigidbodyMovement player;
    public Text instructions;
    public SpriteRenderer sR;
    public Sprite s_1;
    public Sprite s_2; 
    public GameObject textObj;
    private bool canCycle;
    private int action = 0;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            canCycle = true; 
        }
    }
    private void Update()
    {
        if (canCycle)
        {
            CycleText();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        textObj.SetActive(false); 
    }
    private void CycleText()
    {
      
        string str_1 = "Press e to break"; 
        string str_2 = "NEW ABILITY ACQUIRED: \"TIMESLOW\"\n\n\n\nPress e to clear";
        string str_3 = "Press Q to slow time.\n This ability lasts for a limited amount of time, so use it wisely!";
        textObj.SetActive(true);
        if (Input.GetKeyUp(KeyCode.E))
        {
            action++; 
        }
        switch (action)
        {
            case 0:
                instructions.text = str_1;
                
                break;
            case 1:
                sR.sprite = s_1;
                instructions.text = "Press e to equip item";
                break; 
            case 2:
                sR.sprite = s_2;
                instructions.text = str_2;
                player.canSlow = true; 
               
                break;
            case 3:
                instructions.text = str_3;
                break;
            case 4:
                textObj.SetActive(false);
                break;
            case 10:
                textObj.SetActive(true);
                break;
            case 15:
                textObj.SetActive(true);
                instructions.text = "seriously, stop.";
                break;
            case 20:
                textObj.SetActive(true);
                instructions.text = "ok now there really isn't any text left, go away";
                break; 
            default:
                textObj.SetActive(true); 
                instructions.text = "there isn't any text left, go away";
                break; 
        }
        
        
    }
}
