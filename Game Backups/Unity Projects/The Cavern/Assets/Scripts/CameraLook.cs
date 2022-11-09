using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public enum RotationDirection
    {
        None,
        Horizontal = (1<< 0),
        Vertical = (1<<1)
    }

    [SerializeField] private float maxVertAngle;
    [SerializeField] private RotationDirection rotationDirection; 
    [SerializeField] private Vector2 sensitivity;
    private Vector2 rotation;

    private void Start()
    {
        rotation = Vector2.zero; 
    }
    private Vector2 GetInput()
    {
        /// gets the input vector 
        Vector2 input = new Vector2(
          Input.GetAxis("Mouse X"),
          Input.GetAxis("Mouse Y")
          );
        return input; 

    }
    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVertAngle, maxVertAngle); 
    }
    private void Update()
    {
        /// the wanted camera velocity is determined by the mouse input multiplied by the sensitivity
        Vector2 wantedVelocity = GetInput() * sensitivity;

        /// zeros the wanted velocity if the controller does not rotate in that direction 
        if((rotationDirection & RotationDirection.Horizontal) == 0)
        {
            wantedVelocity.x = 0; 
        }
        if((rotationDirection & RotationDirection.Vertical) == 0)
        {
            wantedVelocity.y = 0; 
        }
        

        /// adds the wanted velocity to the rotation 
        rotation += wantedVelocity * Time.deltaTime;
        rotation.y = ClampVerticalAngle(rotation.y); 
         

        /// converts the rotation into euler angles 
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0f); 
    }
}
