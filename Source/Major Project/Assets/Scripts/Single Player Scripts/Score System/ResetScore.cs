using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    public void OnClick()
    {
        ScoreController.score = 0;
        CountdownTimer.currentTime = 30f;
    }
}
