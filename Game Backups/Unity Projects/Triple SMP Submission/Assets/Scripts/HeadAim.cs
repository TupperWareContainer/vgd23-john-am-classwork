using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAim : MonoBehaviour
{
    public Transform lookPos; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Look(lookPos); 
    }
    private void Look(Transform lookPosition)
    {
        Vector2 lp = new Vector2(lookPosition.position.x - transform.position.x, lookPosition.position.y - transform.position.y);
        float dX = lp.x;
        float dY = lp.y;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dY, dX);

    }
}
