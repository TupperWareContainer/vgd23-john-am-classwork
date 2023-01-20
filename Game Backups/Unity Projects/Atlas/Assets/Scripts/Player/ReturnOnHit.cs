using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnOnHit : MonoBehaviour
{
    private bool hasCollidedWithValidObj = false;
    private bool collidedWithMiniature = false; 
    private GameObject colGameObject; 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            hasCollidedWithValidObj = true;
            collidedWithMiniature = false; 
            colGameObject = other.gameObject; 
        } 
        else if (other.CompareTag("MiniLevel"))
        {
            hasCollidedWithValidObj = true;
            collidedWithMiniature = true; 
            colGameObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasCollidedWithValidObj = false; 
    }
    public bool hasCollidedWithValid()
    {
        return hasCollidedWithValidObj; 
    }
    public bool hasCollidedWithMiniature()
    {
        return collidedWithMiniature; 
    }
    public GameObject getObj()
    {
        return colGameObject; 
    }
    public Collider[] getCol()
    {
        return colGameObject.GetComponents<Collider>(); 
    }
}
