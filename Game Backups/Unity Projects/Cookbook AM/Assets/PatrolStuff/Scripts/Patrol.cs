using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float moveMult = 0.3f;
    private float tVal = 0;
    public Transform[] patrolRoute;
    private int pointInPatrol = 0;
    
    
    private void FixedUpdate()
    {
        tVal += (Time.fixedDeltaTime * moveMult);
        FollowRoute();
        Debug.Log(tVal);
        Debug.Log(pointInPatrol);
        if ((pointInPatrol + 1 > patrolRoute.Length))
        {
            pointInPatrol = 0;
            tVal = 0;
            return;
        }

    }
    void FollowRoute()
    {
        Transform prevPoint = patrolRoute[pointInPatrol];
        Transform target = (pointInPatrol+1 < patrolRoute.Length) ? patrolRoute[pointInPatrol+1] : patrolRoute[0];
        Debug.DrawLine(prevPoint.position, target.position,Color.green); 
        Vector3 curPos = Vector3.Lerp(prevPoint.position, target.position, tVal);
        transform.position = curPos;
        if (transform.position.Equals(target.position))
        {
            pointInPatrol += 1;
            tVal = 0;
        }

        

    }
    
}
