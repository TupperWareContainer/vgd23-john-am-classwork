using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FakeRain : MonoBehaviour
{
    public GameObject rainPrefab;
    public Transform p1, p2, p3, p4, p5;

    private void Start()
    {
        InvokeRepeating("SpawnRandom", 2.0f, 1.0f); 
    }

    Vector3 getRandomPos()
    {
        Transform spawnPos = p1 ;
        System.Random rand = new System.Random();
        int randNum = rand.Next(1, 5);
        switch (randNum)
        {
            case 1:
                spawnPos = p1;
                break;
            case 2:
                spawnPos = p2;
                break;
            case 3:
                spawnPos = p3;
                break; 
            case 4:
                spawnPos = p4;
                break; 
            case 5:
                spawnPos = p5;
                break; 
        }
        return spawnPos.position; 
    }
   
    void SpawnRandom()
    {
        Vector3 spawnPos = getRandomPos();
        Instantiate(rainPrefab, spawnPos, gameObject.transform.rotation); 
    }
}
