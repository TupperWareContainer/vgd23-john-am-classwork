using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSequence : MonoBehaviour
{
    public Text activeText;
    public Text inactiveText;
    public GameObject player; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            
            
            inactiveText.gameObject.SetActive(true);
            activeText.gameObject.SetActive(false);
            gameObject.SetActive(false);
            if (gameObject.name.Contains("Sequence 4"))
            {
                player.GetComponent<RigidbodyMovement>().canFire = true; 
            }
        }
    }
}
