using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlightcontroller : MonoBehaviour
{
    public GameObject eLight; 
    private void Awake()
    {
        eLight.SetActive(true);  
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            eLight.SetActive(!eLight.activeInHierarchy); 
        } 
    }
}
