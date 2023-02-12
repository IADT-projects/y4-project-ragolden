using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public GameObject scoreBoardContainer;
    private Scoreboard _scoreBoard;
    private int ownerID = -1;
    public int score;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        _scoreBoard = scoreBoardContainer.GetComponent<Scoreboard>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "targetEasy")
        {
            ownerID = other.gameObject.GetComponent<ArrowRequest>().ownership;
            _scoreBoard.SetScoreForPlayer(ownerID, score);
            other.gameObject.GetComponent<ArrowRequest>().ownership = -1;
        }
    }

}
