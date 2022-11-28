using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject fLight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fLight.SetActive(!fLight.activeInHierarchy); 
        }
    }
}
