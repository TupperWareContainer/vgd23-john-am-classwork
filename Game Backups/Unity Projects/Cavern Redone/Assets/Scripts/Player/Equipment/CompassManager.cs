using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassManager : MonoBehaviour
{
    public Material[] getNumbers = new Material[10];
    public MeshRenderer[] setNumbers = new MeshRenderer[5]; 
    public Transform north, compassPointer, playerTransform, otherTarget,compassBase;
    private bool targetOverride = false;
    public float northOffset = 10f;
    public float compassOffset = 0.5f;

    private float angle;
    private float prevAngle;
    private float sAngle = 0f;

    private int[] numberDisplay = new int[5];
    


    private void FixedUpdate()
    {
        north.position = new Vector3(playerTransform.position.x + northOffset, playerTransform.position.y, playerTransform.position.z); 
        pointNorth();
        displayCurrentDepth(); 
    }
    

    private void pointNorth()
    {
        Transform target = targetOverride ? otherTarget : north;
        float dX = (playerTransform.forward.x - target.transform.forward.x);
        float dZ = (-playerTransform.forward.z - target.transform.forward.z); 
        Debug.Log("Playertransform.forward: " + playerTransform.forward);
        prevAngle = this.angle; 
        /**
         * Takes the change in angle and adds that to a sum of the change in angle, it then uses this sum to allow for a smooth rotation of the compass
         * as opposed to the wierd snapping you get by just using the base this.angle  
         */
        this.angle =  Mathf.Rad2Deg * Mathf.Atan2(dZ, dX) +90;
        float dAngle = this.angle - prevAngle;
        sAngle += dAngle;
        float angle = -sAngle *2; 
        Debug.Log("pi mult: " + (angle / Mathf.Rad2Deg) / Mathf.PI);
        Debug.Log($"Compass Stats\ndX: {dX}\ndZ: {dZ}\nangle: {angle} "); 
        Debug.Log("Angle: " + angle); 
        Quaternion yRot = Quaternion.AngleAxis(angle, new Vector3(0f, 1f, 0f));
        Quaternion xRot = Quaternion.AngleAxis(transform.rotation.x, new Vector3(1f, 0f, 0f));
        Quaternion zRot = Quaternion.AngleAxis(transform.rotation.z, new Vector3(0f, 0f, 1f));
        Vector3 eulerRot = new Vector3(xRot.eulerAngles.x, yRot.eulerAngles.y, 0f);
        compassBase.transform.localRotation = Quaternion.Euler(eulerRot);
        //compassPointer.transform.localRotation = 
      
    }
    /// <summary>
    /// Returns the corresponding number decal for a given number 
    /// </summary>
    /// <param name="num"></param> the number to find a decal for (0-9); 
    /// <returns></returns>
    public Material getNumberDecal(int num)
    {
        if(num <=9 && num >= 0)
        {
            return getNumbers[num]; 
        }
        else
        {
            Debug.LogWarning($"Number {num} does not have an associated decal!"); 
            return null; 
        }
    }
    private void displayCurrentDepth()
    {
        Debug.Log("Start!"); 
        int depth = Mathf.FloorToInt(Mathf.Abs(playerTransform.position.y));
        char[] dString = depth.ToString().ToCharArray();
        switch (dString.Length)
        {
            case 1:
                setNumbers[0].material = getNumberDecal(dString[0] - '0');
                setNumbers[1].material = getNumberDecal(0);
                setNumbers[2].material = getNumberDecal(0);
                setNumbers[3].material = getNumberDecal(0);
                setNumbers[4].material = getNumberDecal(0);
                break;
            case 2:
                setNumbers[0].material = getNumberDecal(dString[1] - '0');
                setNumbers[1].material = getNumberDecal(dString[0] - '0');
                setNumbers[2].material = getNumberDecal(0);
                setNumbers[3].material = getNumberDecal(0);
                setNumbers[4].material = getNumberDecal(0);
                break;
            case 3:
                setNumbers[0].material = getNumberDecal(dString[2] - '0');
                setNumbers[1].material = getNumberDecal(dString[1] - '0');
                setNumbers[2].material = getNumberDecal(dString[0] - '0');
                setNumbers[3].material = getNumberDecal(0);
                setNumbers[4].material = getNumberDecal(0);
                break;
            case 4:
                setNumbers[0].material = getNumberDecal(dString[3] - '0');
                setNumbers[1].material = getNumberDecal(dString[2] - '0');
                setNumbers[2].material = getNumberDecal(dString[1] - '0');
                setNumbers[3].material = getNumberDecal(dString[0] - '0');
                setNumbers[4].material = getNumberDecal(0);
                break; 
            case 5:
                setNumbers[0].material = getNumberDecal(dString[4] - '0');
                setNumbers[1].material = getNumberDecal(dString[3] - '0');
                setNumbers[2].material = getNumberDecal(dString[2] - '0');
                setNumbers[3].material = getNumberDecal(dString[1] - '0');
                setNumbers[4].material = getNumberDecal(dString[0] - '0');
                break; 
        }
        Debug.Log("depth: " + dString);       
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
