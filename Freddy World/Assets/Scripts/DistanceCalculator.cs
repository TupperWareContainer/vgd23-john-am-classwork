using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
   // Vector3 p1_pos,p2_pos; 

    // Start is called before the first frame update
    /*(void Start()
    {
       // p1_pos = p1.position;
        //p2_pos = p2.position; 
    }*/

    // Update is called once per frame
    void Update()
    {
        Debug.Log(DistanceCalc(p1.position, p2.position)); 
    }
    public float DistanceCalc(Vector3 p1, Vector3 p2)
    {
        float dx = (p2.x - p1.x)* (p2.x - p1.x);
        float dy = (p2.y - p1.y) * (p2.y - p1.y);
        float dz = (p2.z - p1.z) * (p2.z - p1.z);
        float distance = Mathf.Sqrt(dx + dy+dz);
        return distance; 
    }
    public Vector3 CentCalc(Vector3 p1, Vector3 p2)
    {
        float dx = (p2.x + p1.x)/2;
        float dy = (p2.y + p1.y)/2;
        float dz = (p2.z + p1.z)/2;
        Vector3 output = new Vector3(dx, dy, dz); 
        return output; 
    }
}
