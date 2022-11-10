using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Camera cam;
    private Transform camTransform;
    public float mouseSensitivity = 2f; 
    private bool cursorLock = false;
    private float modHAngle = 0;
    private float modVAngle = 0;
    private float vAngle;
    private float hAngle;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = cam.gameObject.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        if (Input.GetKeyDown(KeyCode.L))
        {
            cursorLock = !cursorLock; 
        }
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false; 
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }
    }

    private void LookAtMouse()
    {
        // gets the position of the mouse 
        Vector3 mousePos = cam.ScreenToViewportPoint(Input.mousePosition); 
        // determines the scale of each axis in relation to the field of view
        float camScaleH = (Screen.width /cam.fieldOfView) * 15;
        float camScaleV = (Screen.height / cam.fieldOfView) * 15;
        // creates a vertical and horizontal movement increment which is determined by the position of the mouse in the viewport and the fov scale of the camera 
        modHAngle += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        modVAngle += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        /*float vAngle = ((mousePos.y) * camScaleV); 
        float hAngle = ((mousePos.x) * camScaleH); */

        //Input.GetAxis("Mouse Y")
        vAngle = 90 +modVAngle; 
        hAngle = modHAngle;
       
        Debug.Log($"vAngle: {vAngle}\n hAngle {hAngle}"); 
        vAngle = Mathf.Clamp(vAngle, 90, 270); 
        // cool rotation stuff 
        Quaternion xRot = Quaternion.AngleAxis(vAngle, new Vector3(1f, 0f, 0f));
        Quaternion yRot = Quaternion.AngleAxis(hAngle, new Vector3(0f, 1f, 0f));
        Debug.Log(xRot.eulerAngles + "\n" + yRot.eulerAngles);
        Vector3 eulerRot = new Vector3(xRot.eulerAngles.x, yRot.eulerAngles.y+90, 0f); 
       
        camTransform.rotation = Quaternion.Euler(eulerRot);
       
        transform.rotation = Quaternion.Euler(yRot.eulerAngles); 
        
        



    }
}
