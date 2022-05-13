using UnityEngine;
using TMPro;

public class ScoreUI : SessionUI
{
    [SerializeField] private TextMeshProUGUI scoreField;

    private int prevScore = 0;

    public override void Init(SessionData data)
    {
        base.Init(data);
        scoreField.text = "0";
    }

    private void UpdateScore()
    {
        scoreField.text = sessionData.Score.ToString();
        prevScore = sessionData.Score;
    }

    private void Update()
    {
        if (sessionData.Score != prevScore)
            UpdateScore();
    }
}