using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public Transform player;
    public float playerStart;
    public bool stopScoring= false;
    private float defualtFontSize = 36;
    private float increasedFontSize = 50;
    private float currentFontsize = 0;
    private float decrementFontSize = 1f;
    public int score;
    public int points;
    void Start() {
        currentFontsize = defualtFontSize;    
        playerStart = player.position.z;
        score = 0;
    }
    void FixedUpdate() {
        if (currentFontsize > defualtFontSize) {
            currentFontsize = currentFontsize -decrementFontSize;
        }
        //Debug.Log(currentFontsize);
        score = (int)(points + ((player.position.z -playerStart)/10));
        scoreText.SetText((score).ToString("0"));
        
        if (score % 100 == 0 && (score) != 0)
        {
            Debug.Log(score % 100);
            if (score % 1000 == 0)
            {
                currentFontsize = increasedFontSize + increasedFontSize;
            } else {
                currentFontsize = increasedFontSize;
            }
        }
        scoreText.fontSize = currentFontsize;
    }
 
    //Usage first number should be the score to add, the second should be a multipler
    //If there is one in the future.
    public void addScore(int addScore) {
        points = points + addScore;
        if (addScore >= 100) {
            currentFontsize = increasedFontSize;
            if (addScore >= 1000) {
                currentFontsize = increasedFontSize + increasedFontSize;
            }
        }
    }
}