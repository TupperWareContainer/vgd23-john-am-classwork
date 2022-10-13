using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera cam;
    public Vector3 mousePos;
    public Transform debugObj;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        Debug.Log($" screen to world point: { cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane))}");
        Debug.Log($"mouseposx {Input.mousePosition.x}"); 
        transform.position = mousePos; 
    }
    
}
