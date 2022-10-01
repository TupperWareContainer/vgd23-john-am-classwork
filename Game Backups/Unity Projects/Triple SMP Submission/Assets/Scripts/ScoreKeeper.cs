using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    private int x; 
    public Text uIScore;
    public Text[] styleText = new Text[6];
    public Slider styleSlider;
    public Text grade; 
    private float cScore = 0;
    private float timer; 
    public int finalscore = 0;
    public Rigidbody2D player;
    public float speedMultiplier; 
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        ResetStyleText();
       
    }
    void Update()
    {
        speedMultiplier = player.velocity.sqrMagnitude / 100;
        styleSlider.value = cScore;
        uIScore.text = $"Score: {score}";
        Debug.Log($"Styleslider value {styleSlider.value}");
        Debug.Log($"speedMultiplier: {speedMultiplier}");
        //StyleMeterScore(); 
       
    }
    public void QueueStyleText(string sT)
    {
        int b = 0;
        
        bool textAdded = false;
        while (!textAdded)
        {
            if(styleText[b].text != "-")
            {
                if (styleText[b].text.Contains(sT))
                {
                    x++;
                    styleText[b].text = $"{sT} (x{x})";
                    textAdded = true;
                   
                }
                else
                {
                    b++; 
                }
            }
            else if (styleText[b].text.Contains("-"))
            {
                styleText[b].text = sT;
                textAdded = true;
            }
        }
    }
    public void StyleMeterScore()
    {
        //bool hasAppliedScore = false;
       
        if(finalscore < 1)
        {
            styleSlider.maxValue = 3; 
        }

        styleSlider.value = cScore;
        // if (!hasAppliedScore)
        //{ 
        if (cScore >= styleSlider.maxValue && finalscore <= 5)
        {
            cScore = 0;
            finalscore++;
            Debug.Log($"Finalscore {finalscore}");

        }
        else if (finalscore > 5)
        {
            finalscore = 5;
        }
        for (int a = 0; a < styleText.Length; a++){

                
                if (styleText[a].text.Contains("+ENEMY DOWN") || styleText[a].text.Contains($"+ENEMY DOWN {x}"))
                {
                    cScore+= 1 + speedMultiplier;

                Debug.Log($"cScore: {cScore}");
                    Debug.Log("if you see this message multiple times, something has gone wrong");
                    //hasAppliedScore = true;

                }
                else
                {
                    a++;
                }
        }
            
        //} 

        switch (finalscore)
        {
            case 1: 
                grade.text = "D";
                grade.color = Color.blue;
                styleSlider.value = 0;
                styleSlider.maxValue = 5;
                break;
            case 2:
                grade.text = "C";
                grade.color = Color.green;
                styleSlider.value = 0;
                styleSlider.maxValue = 8;
                break;
            case 3:
                grade.text = "B";
                grade.color = Color.yellow;
                styleSlider.value = 0;
                styleSlider.maxValue = 10;
                break;
            case 4:
                grade.text = "A";
                grade.color = new Color(255, 160, 0);
                styleSlider.value = 0;
                styleSlider.maxValue = 15;
                break;
            case 5:
                grade.text = "S";
                grade.color = Color.red;
                styleSlider.value = 0;
                styleSlider.maxValue = 20;
                break; 


        }
        if(finalscore > 0)
        {
            timer += Time.deltaTime;
        }
        if(timer  >= 15)
        {
            timer = 0f;
            finalscore = 0; 
            ResetStyleText(); 
          
        }


    }
    private void ResetStyleText()
    {
        Text activetext;
        for (int i = 0; i < styleText.Length; i++)
        {
            activetext = styleText[i];
            activetext.text = "-";
        }
    }
}
