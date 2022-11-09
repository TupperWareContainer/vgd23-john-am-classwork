using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFerns : MonoBehaviour
{
    public GameObject[] fernVars = new GameObject[3];
    public int fernCycles = 3;
    public int posVariation = 3;
    int i;
    int timer;
    float yPos; 
    public void Start()
    {
        
    }
    public void Update()
    {
        timer += Mathf.CeilToInt(Time.deltaTime);
        Debug.Log($"timer: {timer}"); 
        
        Debug.Log("spawnattempt");
       
            while(i < fernCycles)
            {
                GameObject.Instantiate(fernVars[0], position: new Vector3(randPosition().x,yPos, randPosition().z), transform.rotation);
                Debug.Log("spawn");
                i++; 
            }
        
    }
   
    private float rng()
    {
        int seed = Mathf.CeilToInt(Time.time);  
        Random.InitState(seed);
        Debug.Log($"seed = {seed}"); 
        return Random.Range(-posVariation, posVariation); 
    }
    private Vector3 randPosition()
    {
        /* preforms a spherecast at a random position relative to the FernGroup Gameobject, if the spherecast returns a valid 
         (is in contact with the ground) position then the method returns that position, if not, then the method runs recursively until a valid position is found*/
        float posVar = rng();
        Debug.Log($"posVar = {posVar}"); 
        Vector3 origin = transform.position; 
        float radius = 15f;
        Vector3 Spawnpos;
        LayerMask layermask = ~3;
        RaycastHit hit;
        Vector3 direction = new Vector3(transform.position.x + posVar, transform.position.y + posVar, transform.position.z + posVar);

        if (Physics.Raycast(origin: origin,direction: direction, out hit, maxDistance: radius, layerMask: layermask))
        {
            if(hit.point.y < transform.position.y)
            {
                Spawnpos = hit.point;
                yPos = hit.point.y; 
                return Spawnpos;
            }
            else
            {
                return randPosition();
            }
        }
        else
        {
            return randPosition();
        }


    }

    
}
