using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassManager : MonoBehaviour
{
    public Material[] getNumbers,setNumbers = new Material[10];
    public Transform north, compassPointer, playerTransform, otherTarget;
    private bool targetOverride = false;
    public float northOffset = 10f; 


    private void FixedUpdate()
    {
        north.position = new Vector3(playerTransform.position.x + northOffset, playerTransform.position.y, playerTransform.position.z); 
        pointNorth(); 
    }

    private void pointNorth()
    {
        Transform target = targetOverride ? otherTarget : north;
        float dX = (playerTransform.forward.magnitude + playerTransform.position.x) - target.transform.position.x;
        float dZ = -(playerTransform.right.magnitude + playerTransform.position.z) - target.transform.position.z;
        
    
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dZ, dX);
        Quaternion yRot = Quaternion.AngleAxis(angle, new Vector3(0f, 1f, 0f));
        Quaternion xRot = Quaternion.AngleAxis(transform.rotation.x, new Vector3(1f, 0f, 0f));
        Quaternion zRot = Quaternion.AngleAxis(transform.rotation.z, new Vector3(0f, 0f, 1f));
        Vector3 eulerRot = new Vector3(xRot.eulerAngles.x, yRot.eulerAngles.y, 0f);
        compassPointer.transform.localRotation = Quaternion.Euler(eulerRot); 
      
    }

    public void SetTarget(Transform newTarget)
    {
        targetOverride = true;
        otherTarget = newTarget; 
    }
    public void TrackNorth()
    {
        targetOverride = false; 
    }


}
