using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Camera cam;
    private Transform camTransform; 
    // Start is called before the first frame update
    void Start()
    {
        camTransform = cam.gameObject.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse(); 
    }

    private void LookAtMouse()
    {
        // gets the position of the mouse 
        Vector3 mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        // determines the scale of each axis in relation to the field of view
        float camScaleH = Screen.width / cam.fieldOfView;
        float camScaleV = Screen.height / cam.fieldOfView;
        // creates a vertical and horizontal movement increment which is determined by the position of the mouse in the viewport and the fov scale of the camera 
        float vAngle = 0;
        float hAngle = 0;

        vAngle += (-mousePos.y * camScaleV);
        hAngle += (mousePos.x * camScaleH);
        // cool rotation stuff 
        Quaternion xRot = Quaternion.AngleAxis(vAngle, new Vector3(1f, 0f, 0f));
        Quaternion yRot = Quaternion.AngleAxis(hAngle, new Vector3(0f, 1f, 0f));
        Debug.Log(xRot.eulerAngles + "\n" + yRot.eulerAngles);
        Vector3 eulerRot = new Vector3(xRot.eulerAngles.x, yRot.eulerAngles.y+90, 0f); 
       
        camTransform.rotation = Quaternion.Euler(eulerRot);
       
        transform.rotation = Quaternion.Euler(yRot.eulerAngles); 
        
        



    }
}
