using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowstick : MonoBehaviour
{
    public GameObject glowStickPrefab;
    public Transform launchPosition;
    public Transform player;  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(glowStickPrefab, launchPosition.position, player.rotation); 
        }
    }
}
