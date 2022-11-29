using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MapManager : MonoBehaviour
{

    public GameObject currentMap;
    public MouseLook player;
    public GameObject[] mapChunks;
    

    private bool[] canBeActive;
    private bool updateChunks = false; 
    private void Start()
    {
        canBeActive = new bool[mapChunks.Length];
        StartCoroutine(chunkStatus());
    }
    private void Update()
    {
        if (Input.GetButtonDown("Map")){
            currentMap.SetActive(!currentMap.activeInHierarchy);
            PauseGame();
            updateChunks = true; 
        }
        else
        {
            updateChunks = false; 
        }
        if (currentMap.activeInHierarchy)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                PauseGame();
                currentMap.SetActive(false); 
            }
        }
    }
    
    private void PauseGame()
    {
        bool isPaused = (Time.timeScale > 0f) ? false : true;
        Time.timeScale = (isPaused) ? 1f : 0f;
        player.ScreenLock(!isPaused); 
    }
    /// <summary>
    /// Gets the next currently available map chunk, used for debug purposes  
    /// </summary>
    /// <returns></returns>
    public int GetNextNumber()
    {
        for(int i = 0; i < mapChunks.Length; i++)
        {
            if(canBeActive[i] == false)
            {
                return i; 
            }
        }
        return -1;
    }
    /// <summary>
    /// Sets the activation status of the designated map chunk 
    /// </summary>
    /// <param name="chunk"></param> the chunk to be modified 
    /// <param name="status"></param> the activation status of the chunk (true = can be activated, false = cannot be activated) 
    public void SetChunkStatus(int chunk,bool status)
    {
        canBeActive[chunk] = status; 
    }
    IEnumerator chunkStatus()
    {
        yield return new WaitUntil( ()=> updateChunks);
        if (currentMap.activeInHierarchy)
        {
            for (int i = 0; i < mapChunks.Length; i++)
            {
                if (canBeActive[i])
                {
                    mapChunks[i].SetActive(true);
                }
                else
                {
                    mapChunks[i].SetActive(false); 
                }
            }
        }
    }
    
}
