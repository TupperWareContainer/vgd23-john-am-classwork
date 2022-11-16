using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove : MonoBehaviour
{
    public GameObject origin, target, mover;
    private float tValue = 0;
    private bool left, right = false;
    private void Start()
    {
       
    }
    private void FixedUpdate()
    {
       if(mover.transform.position == origin.transform.position)
        {
            left = true;
            right = false; 
        }
       else if(mover.transform.position == target.transform.position)
        {
            right = true;
            left = false; 
        }
        if (left)
        {
            tValue += .01f;
        }
        else if (right)
        {
            tValue -= .01f;
        }
        MoveTarget(); 

    }
   void MoveTarget()
    {
      
        mover.transform.position= Vector3.Lerp(origin.transform.position, target.transform.position, tValue);
       
    }

}
