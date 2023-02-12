using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    
    public static int score;
    public float highscore;

    public TMP_Text scoreDisplay;
    public TMP_Text highscoreDisplay;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("Highscore");
        //highscoreDisplay.text = highscore.ToString();
    }
    // Update is called once per frame
    private void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("Highscore", highscore);
        }

        scoreDisplay.text = score.ToString();
        //highscoreDisplay.text = highscore.ToString();
    }
}
