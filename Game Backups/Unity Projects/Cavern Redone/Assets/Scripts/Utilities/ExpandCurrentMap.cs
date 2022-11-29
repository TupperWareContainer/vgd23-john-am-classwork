using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandCurrentMap : MonoBehaviour
{
    private MapManager mapManager; 
    public int designatedChunk;
    private void Start()
    {
       mapManager =  GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("collide"); 
        if (other.CompareTag("Player"))
        {
            Debug.Log("player"); 
            if (Input.GetButtonDown("Interact"))
            {
                mapManager.SetChunkStatus(designatedChunk, true);
                Destroy(gameObject.GetComponent<ExpandCurrentMap>());
            }
        }
    }
}
