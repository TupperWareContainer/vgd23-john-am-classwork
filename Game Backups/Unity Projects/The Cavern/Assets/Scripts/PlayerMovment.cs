using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController characterController;
    public float speedMult = 3f; 
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move((Vector3.forward * speedMult) * Time.deltaTime);  
        }  
    }
}
