using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Scoring : MonoBehaviour
{
    public GameObject scoreBoardContainer;

    public GameObject bow;
    //public GameObject bowTwo;
    private Bow Bow;
    //private Bow BowTwo;
    
    private Scoreboard _scoreBoard;
    private int ownerID = -1;
    public int score;
    public TMP_Text scoreText;  
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        _scoreBoard = scoreBoardContainer.GetComponent<Scoreboard>();
        Bow = bow.GetComponent<Bow>();
        //BowTwo = bowTwo.GetComponent<Bow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("arrow"))
        {
            if (Bow.isSelected)
            {
                ownerID = GameObject.Find("Bow").GetComponent<BowRequest>().ownership;
                _scoreBoard.SetScoreForPlayer(ownerID, score);
                GameObject.Find("Bow").GetComponent<BowRequest>().ownership = -1;
            }
        }
    }
}