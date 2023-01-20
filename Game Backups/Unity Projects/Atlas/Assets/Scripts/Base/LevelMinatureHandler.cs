using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The general idea is to create a level miniature and then translate the real player & gameobjects in the scene onto that miniature
/// level minatures have to be to scale to work
/// </summary>
public class LevelMinatureHandler : MonoBehaviour
{
    [Header("General Settings")]
    public float LevelScale = 0.01f;
    public bool hasMiniatures = false;
    public bool recursivePhysics = false; 
    public Vector3 levelPosition = new Vector3(0f, 0f, 0f);

    private bool isHeld = false; 
    private Rigidbody rb; 
    [Header("Outside References")]
    public GameObject player;
    public GameObject[] movables;
    //public Rigidbody[] movableRB; 
    [Header("Miniatures")]
    public Transform playerMiniature; 
    public GameObject[] miniatures;
   // public Rigidbody[] miniatureRB; 
    int pos = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        playerMiniature.localPosition = player.transform.position - levelPosition;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMiniature.transform.localPosition = player.transform.position - levelPosition;
        if (hasMiniatures)
        {
            if (recursivePhysics && isHeld)
            {
                recursiveMiniEmulation();
                StartCoroutine(setPhysicsScale());
            }
            else normalMiniEmulation(); 
        }
    }
    private void normalMiniEmulation()
    {
        miniatures[pos].transform.localPosition = movables[pos].transform.position - levelPosition;
        pos = (pos < miniatures.Length - 1) ? pos + 1 : 0;
    }
    private void recursiveMiniEmulation()
    {
        movables[pos].transform.position = miniatures[pos].transform.localPosition + levelPosition;
        movables[pos].transform.rotation = miniatures[pos].transform.rotation; 
        pos = (pos < miniatures.Length - 1) ? pos + 1 : 0;
    }
    IEnumerator setPhysicsScale()
    {
        yield return new WaitUntil(() => recursivePhysics); 
        foreach (GameObject miniature in miniatures)
        {
            miniature.GetComponent<Rigidbody>().velocity *= LevelScale * Time.deltaTime; 
        }
    }

    #region ACCESSORS AND MUTATORS
    public bool getHeld()
    {
        return isHeld;
    }
    public void setHeld(bool held)
    {
        isHeld = held; 
    }
    #endregion


}
