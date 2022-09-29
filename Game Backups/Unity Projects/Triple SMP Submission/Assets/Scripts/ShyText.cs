using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyText : MonoBehaviour
{
    float timer; 
    private void Awake()
    {
        timer = 0; 
    }
    private void Update()
    {
        timer += Time.deltaTime; 
        if(timer > 3f)
        {
            gameObject.SetActive(false); 
        }
    }
}
