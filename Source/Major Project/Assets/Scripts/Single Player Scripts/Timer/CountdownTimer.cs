using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public static float currentTime = 0f;
    public float startingTime = 30f;

    [SerializeField] TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            countdownText.text = currentTime.ToString("Time's Up! You scored " + ScoreController.score + " points!");
            //GetComponent<ArrowController>().enabled = false;
            //GameObject.Find("Arrow").GetComponent<ArrowController>().enabled = false;
        }
    }
}
