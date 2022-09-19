using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawConnector : MonoBehaviour
{
    DistanceCalculator dC;
    public Transform line; 
    // Start is called before the first frame update
    void Start()
    {
        dC = GetComponent<DistanceCalculator>();  
    }

    // Update is called once per frame
    void Update()
    {
        line.LookAt(dC.p2.position);
        line.position = dC.CentCalc(dC.p1.position,dC.p2.position);
        line.localScale = new Vector3(0.5f, 0.5f, dC.DistanceCalc(dC.p1.position, dC.p2.position));
    }
}
