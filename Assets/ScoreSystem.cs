using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public Animator scoreLabelAnimator;

    private int currentScore;

    private void Start()
    {
        scoreLabel.text = "0";
    }

    public void AddPoints(int amount)
    {
        currentScore += 10;
        scoreLabel.text = currentScore.ToString();
        scoreLabelAnimator.SetTrigger("ScoreAnimation");
    }

    public void ReducePoints(int amount)
    {
        currentScore -= 10;
        scoreLabel.text = currentScore.ToString();
    }

    private void RestartValues()
    {
        Start();
    }
}
