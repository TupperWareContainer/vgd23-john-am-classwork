using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFixturePlacer : MonoBehaviour
{
    public GameObject heldLightFixture;
    public GameObject placementHighlight;
    public GameObject lightFixture;

    public float range = 10f;
    private int interactLayer =~ 4;

    public Transform cameraTransform; 

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(origin: cameraTransform.position, direction: cameraTransform.forward);
        RaycastHit hit;
        Quaternion desiredRot = new Quaternion(); 
        Debug.DrawRay(ray.origin, ray.direction, Color.red); 
        Vector3 placementPos;
        if (heldLightFixture.activeSelf)
        {
           
            if (Physics.Raycast(ray, out hit, maxDistance: range, layerMask: interactLayer))
            {
                placementHighlight.SetActive(true);
                placementPos = hit.point;
                desiredRot = new Quaternion(0, 0, 0, 0); //Quaternion.AngleAxis(Quaternion.Angle(transform.rotation, hit.transform.rotation),hit.transform.position); 
                placementHighlight.transform.rotation = desiredRot;
                placementHighlight.transform.position = placementPos;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Object.Instantiate(lightFixture, position: placementPos, rotation: desiredRot);
                }
            }
        }
        else
        {
            placementHighlight.SetActive(false);
        }
        
    }
}
