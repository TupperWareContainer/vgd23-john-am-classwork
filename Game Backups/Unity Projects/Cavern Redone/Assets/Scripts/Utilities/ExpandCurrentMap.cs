using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandCurrentMap : MonoBehaviour
{
    private MapManager mapManager = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
    public int designatedChunk;



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                mapManager.SetChunkStatus(designatedChunk, true);
                Destroy(gameObject.GetComponent<ExpandCurrentMap>()); 
            }
        }
    }
}
