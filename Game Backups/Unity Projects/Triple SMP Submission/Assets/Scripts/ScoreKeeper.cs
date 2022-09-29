using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    
    public Text uIScore;
    public Text[] styleText = new Text[6];
    public Slider styleSlider;
    public Text grade; 
  
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        ResetStyleText();  
    }
    void Update()
    {
    
        uIScore.text = $"Score: {score}";
        StyleMeterScore(); 
    }
    public void QueueStyleText(string sT)
    {
        int b = 0;
        bool textAdded = false;
        while (!textAdded)
        {
            if(styleText[b].text != "-")
            {
                b++;
                 
            }
            else
            {
                styleText[b].text = sT;
                textAdded = true;
            }
        }
    }
    public void StyleMeterScore()
    {
        int finalscore = 0;
        int cScore = 0;
        float timer = 0; 
        if(finalscore < 1)
        {
            styleSlider.maxValue = 3; 
        }
        for (int a = 0; a < styleText.Length; a++)
        {

            switch (styleText[a].text)
            {
                case "+ENEMY DOWN":
                    cScore +=1;
                    styleSlider.value = cScore;
                    break;
                default:
                    styleSlider.value = cScore; 
                    break; 

            }
            if(cScore > styleSlider.maxValue)
            {
               
                finalscore++;
                
                cScore = 0;
            }
           
        }
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
        if(timer  > 3)
        {
            timer = 0f;
            finalscore--;
          
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
