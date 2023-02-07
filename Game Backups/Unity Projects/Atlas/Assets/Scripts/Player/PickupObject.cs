using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    private Rigidbody playerRB; 
    [Header("External References")]
    public Transform boxPos;
    public ReturnOnHit rHit;
    public Transform tranToLookAt; 
    [Header("Preferences")]
    public float throwingVMod = 0.3f;
    public float pickupForce = 100f; 
    public float throwForce; 
    [Header("Debug")]
    public bool hasEquipped; 
    [SerializeField] private GameObject equippedObj = null;
    private Collider[] equippedObjCollider; 

    private bool allowHold;
    private Quaternion initialObjRot; 
    // private Vector3 miniPosOld, miniPosNew, miniVelocity; 
   // private Vector3 initHeldObjPos; 

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
                initialObjRot = equippedObj.transform.rotation; 
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
       
        foreach(Collider col in objCollider)
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col, true);
        }
        //objRB.useGravity = false; 
        jankyCollision(objToHold.transform, objRB); 
    }
    void jankyCollision(Transform colTransform, Rigidbody colRigidbody)
    {
        float modForce = pickupForce * (boxPos.position - colTransform.position).magnitude; 
        colRigidbody.velocity = (Vector3.Normalize(boxPos.position - colTransform.position) * modForce) * Time.fixedDeltaTime;

        colTransform.LookAt(tranToLookAt);
        colTransform.eulerAngles = new Vector3(initialObjRot.eulerAngles.x, colTransform.eulerAngles.y, initialObjRot.eulerAngles.z); 
       // colRigidbody.AddForce((Vector3.Normalize(boxPos.position - colTransform.position) * pickupForce) * Time.fixedDeltaTime,ForceMode.Impulse);
    }
    private void dropGameObject(GameObject objToHold, Collider[] objCollider)
    {

        //objToHold.GetComponent<Rigidbody>().useGravity = true;  
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
   /* private Vector3 calculateVelocity(Vector3 oldPos,Vector3 newPos,float dTime,float vMod)
    {
        Vector3 delta = newPos - oldPos;
        delta = Vector3.Normalize(delta); 
        return ((delta * vMod) / dTime); 
    }*/

}

