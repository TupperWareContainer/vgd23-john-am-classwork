using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    private int x;
    public int maxStyleScore;
    //public int finalscore = 0;

    public bool hasAppliedScore = false; 

    public float cScore = 0;
    private float timer;
    public float speedMultiplier;

    private float g_A, g_B, g_C, g_D, g_S; 
    public Text uIScore;
    public Text[] styleText = new Text[6];
    public Slider styleSlider;
    public Text grade;
    public Rigidbody2D player;

    

   
 

    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        /// resets the style text and calculates the thresholds for grading style
        g_S = maxStyleScore; /// Grades are based on 20% increments starting at 20% and ending at 100% 
        g_A = maxStyleScore * .80f;
        g_B = maxStyleScore * .50f;
        g_C = maxStyleScore * .30f;
        g_D = maxStyleScore * .20f; 
        ResetStyleText();
        score += 1; 
       
    }
    void Update()
    {
        speedMultiplier = Mathf.Clamp(player.velocity.sqrMagnitude / 100,0,4);
        styleSlider.value = cScore;
        uIScore.text = $"Enemies Left: {score}";
        Debug.Log($"Styleslider value {styleSlider.value}");
        Debug.Log($"speedMultiplier: {speedMultiplier}");
        //StyleMeterScore(); 
        if (hasAppliedScore)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }
        if (timer >= 4f)
        {
            // cScore--;
            //styleSlider.value = cScore;
            // finalscore = 0;
            ResetStyleText();
            hasAppliedScore = false; 

        }


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
    public void StyleMeterScore(int rawStyle)
    {
       /*
        * This method is a eldrich abomination of my creation, but the gist is that the score calculated based on values that an instance of the script "EnemyMovement" inputs upon its destruction
        * when the enemy dies, they make a call to this method and the value is stored under the local variable "raw style"
        * processed style is then calculated using the raw style and multiplying it by the speed multiplier (calculated via a 0-4 clamp) 
        * the processed style is then added to the current score, which is then used to calculate the grade that the player should have (F-S) 
        * if the score hasn't changed for a given time, the cScore is subtracted from, this encorages the player to keep moving and killing enemies. 
        */
        float processedStyle = rawStyle * speedMultiplier;
        
        cScore += processedStyle;
        hasAppliedScore = true;
        //bool hasAppliedScore = false;

        /*if(finalscore < 1)
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
                }*/



        //} 

        if (cScore < g_D)
        {
            grade.text = "F"; 
            grade.color = Color.white;
            styleSlider.maxValue = g_D; 
        }
        else if(cScore >= g_D && cScore < g_C)
        {
            grade.text = "D";
            grade.color = Color.blue;
            styleSlider.maxValue = g_C;
        }
        else if(cScore >= g_C && cScore< g_B)
        {
            grade.text = "C";
            grade.color = Color.green;
            
            styleSlider.maxValue = g_B;
        }
        else if(cScore >= g_B && cScore < g_A)
        {
            grade.text = "B";
            grade.color = Color.yellow;
           
            styleSlider.maxValue = g_A;
        }
        else if(cScore >= g_A && cScore < g_S)
        {
            grade.text = "A";
            grade.color = new Color(255, 160, 0);
           
            styleSlider.maxValue = g_S; 
        }
        else if(cScore >= g_S)
        {
            grade.text = "S";
            grade.color = Color.red;
         
            styleSlider.maxValue = g_S; 
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
