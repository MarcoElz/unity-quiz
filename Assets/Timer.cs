using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;
    public Image timeBar;
    public float totalTime = 10;

    private float timer;

    private void Start()
    {
        RestartTimer();
    }

    public void RestartTimer()
    {
        timer = totalTime;
        timeBar.fillAmount = 1.0f;
    }

    private void Update()
    {
        if (!gameManager.IsGameActive())
            return;

        timer -= Time.deltaTime;
        timeBar.fillAmount = timer / totalTime;

        if (timer < 0)
        {
            gameManager.NextQuestion();
        }
    }
}
