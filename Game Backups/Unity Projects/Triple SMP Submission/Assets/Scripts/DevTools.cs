using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public Aim aimer;
    private Vector2 instPos; 
    public GameObject enemyPrefab;

    private void Start()
    {
        instPos = aimer.mousePos; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(enemyPrefab, instPos, enemyPrefab.transform.rotation); 
        }
    }
}
