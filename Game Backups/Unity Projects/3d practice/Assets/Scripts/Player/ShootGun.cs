using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public int bulletDamage = 3;
    public float shootDelay = 3f;
    public Transform instPos;
    public Transform cameraTransform;
    public string enemyTag;
    Ray raycast;
    RaycastHit hit; 
   
    
    private void Update()
    {
        raycast = new Ray(instPos.position, cameraTransform.forward);
        Debug.DrawRay(raycast.origin, raycast.direction, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckForRaycastHit();
            Debug.Log("Pew!"); 
        }
    }
    private void CheckForRaycastHit()
    {
       
        bool output = false; 
        if(Physics.Raycast(raycast, out hit))
        {
            output = hit.collider.CompareTag(enemyTag);
            
        }
        if (output)
        {
            hit.collider.gameObject.GetComponent<EnemyTakeDamage>().TakeDamage(bulletDamage); 
        }
        
    }
}
