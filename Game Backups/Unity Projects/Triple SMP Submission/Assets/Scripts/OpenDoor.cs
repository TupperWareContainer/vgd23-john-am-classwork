using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int enemies;
    public Transform leftDoor;
    public Transform rightDoor; 
    
    void Update()
    {
        if (enemies <= 0)
        {
            leftDoor.Translate(new Vector2(leftDoor.position.x - 1f, leftDoor.position.y));
            rightDoor.Translate(new Vector2(leftDoor.position.x + 1f, leftDoor.position.y)); 
        }  
    }
    
}
