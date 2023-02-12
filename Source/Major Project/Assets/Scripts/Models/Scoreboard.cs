using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Normal.Realtime;

public class Scoreboard : RealtimeComponent
{
    private ScoreboardModel _model;
    public RealtimeAvatarManager _avatarManager;
    private TMP_Text _scoreBoardText;

    private void Awake()
    {
        _scoreBoardText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _avatarManager.avatarCreated += AvatarChangeUpdateScore;
        _avatarManager.avatarDestroyed += AvatarChangeUpdateScore;
    }

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

    private void UpdateScoreBoardText()
    {
        _scoreBoardText.text = _model.scoreBoardText;
    }

    private void SetScoreBoardText()
    {
        int playerID = 0;
        _model.scoreBoardText = "";

        foreach (var item in _avatarManager.avatars)
        {
            playerID = item.Key + 1;
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
