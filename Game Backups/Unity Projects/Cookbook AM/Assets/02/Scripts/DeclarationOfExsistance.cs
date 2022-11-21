using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclarationOfExsistance : MonoBehaviour
{
    private Count c;
    private SpriteRenderer sR; 
    public Color newColor; 
    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>(); 
        System.Random rand = new System.Random();
        double r, g, b;
        r = rand.NextDouble();
        g = rand.NextDouble();
        b = rand.NextDouble();
        newColor = new Color((float)r, (float)g, (float)b);
       
        c = GameObject.Find("Falling Controller").GetComponent<Count>();
        c.rain.Add(gameObject);
        Debug.Log($"{r} {g} {b}");
    }
    private void Update()
    {
        sR.color = newColor;
    }
    private void OnDestroy()
    {
        c.rain.Remove(gameObject); 
    }

}
