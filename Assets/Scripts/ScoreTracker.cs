using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Text scoreLabel;

    private int score;

    void Start()
    {
		ResetScore();
    }

    public void ResetScore()
    {
        this.score = 0;
        UpdateScoreLabel();
    }

    public void AddScore(int score)
    {
        this.score += score;
        UpdateScoreLabel();
    }

    private void UpdateScoreLabel()
    {
        this.scoreLabel.text = "Score: " + score;
    }
}
