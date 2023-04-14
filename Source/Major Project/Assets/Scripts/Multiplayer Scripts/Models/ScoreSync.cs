using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;
using UnityEngine.UI;

public class ScoreSync : RealtimeComponent
{
    //Reference to Model
    private ScoreSyncModel _model;
    private TMP_Text _scoreText;

    private void Awake()
    {
        // Get the reference to the Score Text Game Object
        _scoreText = GetComponent<TMP_Text>();
    }

    private ScoreSyncModel model
    {
        set
        {
            if (_model != null)
            {
                // Unregister from events
                _model.playerScoreDidChange -= ScoreDidChange;
            }
            // store the model
            _model = value;

            if (_model != null)
            {
                // Update the score the match the new value
                UpdateDisplayScore();

                // Register for events so we'll know if the score changes later
                _model.playerScoreDidChange += ScoreDidChange;
            }
        }
    }

    //Updates score when change is detected
    private void ScoreDidChange(ScoreSyncModel model, int value)
    {
        UpdateDisplayScore();
    }

    //Updates score by pulling the data from the model
    private void UpdateDisplayScore()
    {
        _scoreText.text = "Score: " + _model.playerScore;
    }

    //Gets player score attached to Avatars in game
    public int GetScore()
    {
        return _model.playerScore;
    }
    
    public void SetScore(int tempScore)
    {
        _model.playerScore = _model.playerScore + tempScore;
    }
}
