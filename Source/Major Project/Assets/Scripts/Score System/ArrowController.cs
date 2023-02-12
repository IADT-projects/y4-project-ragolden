using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    public int scoreEasy = 5;
    public int scoreMedium = 10;
    public int scoreHard = 15;

    //public AudioSource impact;

    void Start()
    {
        //impact = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("targetEasy"))
        {
            ScoreController.score += scoreEasy;
            //impact.Play();
        }

        if(other.gameObject.CompareTag("targetMedium"))
        {
            ScoreController.score += scoreMedium;
            //impact.Play();
        }

        if(other.gameObject.CompareTag("targetHard"))
        {
            ScoreController.score += scoreHard;
            //Plays the impact noise whenever an arrow comes in contact with a target
            //impact.Play();
        }
    }

    //void Update()
    //{
    //    if (CountdownTimer.currentTime <= 0)
    //    {
    //        scoreEasy = 0;
    //        scoreMedium = 0;
    //        scoreHard = 0;
    //    }
    //}
}
