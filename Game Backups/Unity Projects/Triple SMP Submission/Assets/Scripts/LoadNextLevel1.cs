using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadNextLevel1 : MonoBehaviour
{
    public Scene spaceStationLevel; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log($"loading scene {SceneManager.GetSceneByBuildIndex(1)}"); 
            SceneManager.LoadScene(1); 
            
        }
    }
}
