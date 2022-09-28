using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements; 

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public Text uiScore; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiScore.text = $"Score: {score}"; 
    }
}
