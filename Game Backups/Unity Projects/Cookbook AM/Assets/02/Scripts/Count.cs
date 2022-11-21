using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Count : MonoBehaviour
{
    public List<GameObject> rain;
    public TextMeshProUGUI text; 

    private void Start()
    {
        StartCoroutine(CountGO()); 
    }
    private  IEnumerator CountGO()
    {
       
        int num;
        num = rain.Count;
        string newestSphere = "";
        string print = "numSpheres: 0";
        string output; 
        while (true)
        {
            for (int i = 0; i < num; i++)
            {
                newestSphere = rain[num-1].name; 
                print = $"numSpheres: {rain.Count}";
            }
            output = $"{print}, Newest Sphere: {newestSphere}";
            text.text = output; 
            yield return new WaitForFixedUpdate();
        }
    }
}
