using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Normal.Realtime;

public class Scoreboard : RealtimeComponent
{
    //References Scoreboard model
    private ScoreboardModel _model;
    //Updates internal list of players that join the room
    public RealtimeAvatarManager _avatarManager;
    //Score stored here
    private TMP_Text _scoreBoardText;

    private void Awake()
    {
        _scoreBoardText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        //Whenever an avatar joins or leaves the room, call the AvatarChangeUpdateScore method
        _avatarManager.avatarCreated += AvatarChangeUpdateScore;
        _avatarManager.avatarDestroyed += AvatarChangeUpdateScore;
    }

    //Whenever there is a change in avatars, the score is updated + SetScoreBoardText is called
    private void AvatarChangeUpdateScore(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        SetScoreBoardText();
    }

    private ScoreboardModel model
    {
        set
        {
            if (_model != null)
            {
                // Unregister from events
                _model.scoreBoardTextDidChange -= ScoreBoardDidChange;
            }

            _model = value;

            if (_model != null)
            {
                UpdateScoreBoardText();
                // Register for events
                _model.scoreBoardTextDidChange += ScoreBoardDidChange;
            }
        }
    }

    private void ScoreBoardDidChange(ScoreboardModel model, string value)
    {
        UpdateScoreBoardText();
    }

    //Grabs score stored in the model
    private void UpdateScoreBoardText()
    {
        _scoreBoardText.text = _model.scoreBoardText;
    }

    //Loops through each Avatar in the scene and grabs its score
    private void SetScoreBoardText()
    {
        //Applies unique ID to every user connected to a room
        int playerID = 0;
        _model.scoreBoardText = "";

        foreach (var item in _avatarManager.avatars)
        {
            //Updates scoreboard to say Player 1, 2 etc when new players join
            playerID = item.Key + 1;
            //Access the public score value on the model
            _model.scoreBoardText += "Player " + playerID + ": " + _avatarManager.avatars[item.Key].gameObject.GetComponentInChildren<ScoreSync>().GetScore() + "\n";
        }
    }

    public void SetScoreForPlayer(int clientID, int score)
    {
        // Set the individual score value for the person who hit the targets
        _avatarManager.avatars[clientID].gameObject.GetComponentInChildren<ScoreSync>().SetScore(score);

        // Update the scoreboard to reflect the new score
        SetScoreBoardText();
    }
}
