using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandCurrentMap : MonoBehaviour
{
    private MapManager mapManager; 
    public int designatedChunk;
    Collider c; 
    bool check = false; 
    private void Start()
    {
       mapManager =  GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
          
    }

    private void Update()
    {
        if (check)
        {
            checkForInput(c); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        check = true;
        c = other; 
    }
    private void OnTriggerExit(Collider other)
    {
        check = false; 
    }
    void checkForInput(Collider other)
    {
       
        Debug.Log("collide");
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log($"Expand Chunk: {designatedChunk}");
                mapManager.SetChunkStatus(designatedChunk, true);
                Destroy(gameObject.GetComponent<ExpandCurrentMap>());
            }
        }
    }
}
