using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float sensitivity = 3f;

    [Header("External References")]
    public Transform player;

    float xRot = 0;
    float yRot = 0;
    private void Start()
    {
        sensitivity *= 100; 
    }
    private void Update()
    {
        mouseRotation();
        if (Input.GetKey(KeyCode.L)) Cursor.lockState = CursorLockMode.Confined;
        if (Input.GetKey(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None; 
    }
    void mouseRotation()
    {
        float dX = -(Input.GetAxisRaw("Mouse Y") * sensitivity) * Time.deltaTime;         
        float dY = (Input.GetAxisRaw("Mouse X") * sensitivity) * Time.deltaTime;
        xRot += dX;
        yRot += dY;
        xRot = Mathf.Clamp(xRot, -90, 90); 
        Debug.Log($"xRot: {xRot}, yRot: {yRot}"); 
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.localRotation = Quaternion.Euler(0f, yRot, 0f);

    }
}
