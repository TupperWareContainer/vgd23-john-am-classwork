using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOM : MonoBehaviour
{
    public float timer;
    [SerializeField] Color explodyColor = new Color(255, 255, 0); 
    private void Awake()
    {
        float beginningScale = .01f;
        transform.localScale = new Vector3(beginningScale, beginningScale, beginningScale);
        timer = 0f; 
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        float tScale = 5 * timer;
        if(timer > 5f)
        {
            Destroy(gameObject); 
        }
        transform.localScale = new Vector3(tScale,tScale,tScale);
        gameObject.GetComponent<SpriteRenderer>().color = explodyColor;
    }
}
