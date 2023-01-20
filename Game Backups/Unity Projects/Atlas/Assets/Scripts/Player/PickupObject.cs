using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    private Rigidbody playerRB; 
    [Header("External References")]
    public Transform boxPos;
    public ReturnOnHit rHit;

    [Header("Preferences")]
    public float throwingVMod = 0.3f;
    public float throwForce; 
    [Header("Debug")]
    public bool hasEquipped; 
    [SerializeField] private GameObject equippedObj = null;
    private Collider[] equippedObjCollider; 

    private bool allowHold;
    private Vector3 miniPosOld, miniPosNew, miniVelocity; 

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (rHit.hasCollidedWithValid())
            {
                equippedObj = rHit.getObj();
                equippedObjCollider = rHit.getCol();
                allowHold = !allowHold;
                hasEquipped = !hasEquipped; 
            } 
        }
        if (allowHold && equippedObj != null) holdGameObject(equippedObj, equippedObjCollider);
        else
        {
            if(equippedObj != null) dropGameObject(equippedObj, equippedObjCollider);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (equippedObj != null)
            {
                throwGameObject(equippedObj, equippedObjCollider);
            }

        }
    }
   
    private void holdGameObject(GameObject objToHold,Collider[] objCollider)
    {
        Rigidbody objRB = objToHold.GetComponent<Rigidbody>();
        if (objToHold.GetComponent<LevelMinatureHandler>())
        {
            objToHold.GetComponent<LevelMinatureHandler>().setHeld(true); 
        }
       /* miniPosNew = objToHold.transform.position;
        miniVelocity = calculateVelocity(miniPosOld, miniPosNew, Time.fixedDeltaTime,throwingVMod);
        miniPosOld = miniPosNew; */
        objToHold.transform.position = boxPos.position;
        objToHold.transform.rotation = transform.rotation;
        objRB.velocity = playerRB.velocity;
        foreach(Collider col in objCollider)
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col, true);
        }
    }
    
    private void dropGameObject(GameObject objToHold, Collider[] objCollider)
    {
       foreach(Collider col in objCollider)
       {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col, false);
       }
       if (objToHold.GetComponent<LevelMinatureHandler>())
       {
            objToHold.GetComponent<LevelMinatureHandler>().setHeld(false);
       }
        equippedObj = null; 

    }
    private void throwGameObject(GameObject objToHold, Collider[] objCollider)
    {
        dropGameObject(objToHold,objCollider);
        Rigidbody objRB = objToHold.GetComponent<Rigidbody>();
        objRB.AddForce((transform.forward * throwForce) * Time.deltaTime,ForceMode.Impulse); 
    }
    private Vector3 calculateVelocity(Vector3 oldPos,Vector3 newPos,float dTime,float vMod)
    {
        Vector3 delta = newPos - oldPos;
        delta = Vector3.Normalize(delta); 
        return ((delta * vMod) / dTime); 
    }

}

