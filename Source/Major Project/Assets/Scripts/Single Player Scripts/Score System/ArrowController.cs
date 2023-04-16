using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    public int scoreEasy = 5;
    public int scoreMedium = 10;
    public int scoreHard = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("targetEasy"))
        {
            ScoreController.score += scoreEasy;
        }

        if(other.gameObject.CompareTag("targetMedium"))
        {
            ScoreController.score += scoreMedium;
        }

        if(other.gameObject.CompareTag("targetHard"))
        {
            ScoreController.score += scoreHard;
        }
    }

    void Update()
    {
        if (CountdownTimer.currentTime <= 0)
        {
            scoreEasy = 0;
            scoreMedium = 0;
            scoreHard = 0;
        }
    }
}
