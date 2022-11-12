using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{

    public Transform[] patrol;
    private NavMeshAgent agent;
    public Transform player;

    public float maxVisionDist = 10f; 

    [SerializeField] private bool isPatrol = false; 
    [SerializeField] private int pointInPatrol = 0;

    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        if (!isPatrol)
        {
            Patrol(pointInPatrol); 
        }
        if(transform.position.x == patrol[pointInPatrol].position.x && transform.position.z == patrol[pointInPatrol].position.z)
        {
            pointInPatrol++;
            isPatrol = false; 
        }
        if(pointInPatrol > patrol.Length)
        {
            pointInPatrol = 0; 
        }
        TrackPlayer(); 
    }
    private void Patrol(int dest)
    {
        if (pointInPatrol >= patrol.Length)
        {
            pointInPatrol = 0;
            dest = 0; 
        }
        isPatrol = true; 
        agent.SetDestination(patrol[pointInPatrol].position); 
    }
    private void TrackPlayer()
    {
        Ray visionRay = new Ray(transform.position, transform.forward);
       // Ray trackingRay = new Ray(transform.position, player.transform.position); 
        RaycastHit hit;
        Vector3 distance = new Vector3((transform.position.x - player.position.x), (transform.position.y - player.position.y), (transform.position.z - player.position.z));
        
        Debug.DrawRay(visionRay.origin, visionRay.direction * maxVisionDist); 
        
    }
}
