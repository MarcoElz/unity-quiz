using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public ScoreSystem scoreSystem;
    public Timer timer;

    public TMP_Text questionLabel;
    public TMP_Text[] optionLabels;

    public QuestionData[] questions;

    private int currentQuestionIndex;  

    private bool isGameActive;

    private void Start()
    {
        isGameActive = true;  
        questionLabel.text = questions[0].question;

        for(int i = 0; i < questions[0].options.Length; i++)
        {
            optionLabels[i].text = questions[0].options[i].option;
        }      
    }

    public bool IsGameActive()
    {
        return isGameActive;
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;
        if(currentQuestionIndex < questions.Length)
        {
            timer.RestartTimer();

            questionLabel.text = questions[currentQuestionIndex].question;

            for (int i = 0; i < questions[currentQuestionIndex].options.Length; i++)
            {
                optionLabels[i].text = questions[currentQuestionIndex].options[i].option;
            }
        }
        else
        {
            Debug.Log("Game Over");
            isGameActive = false;
        }
    }

    public void OptionSelected(int index)
    {
        if (!isGameActive)
            return;

        //Correct
        if(questions[currentQuestionIndex].options[index].isCorrect)
        {
            scoreSystem.AddPoints(10);
        }
        else //Incorrect
        {
            scoreSystem.ReducePoints(10);
        }

        NextQuestion();
    }
}


[System.Serializable]
public struct QuestionData
{
    public string question;
    public Option[] options;
}

[System.Serializable]
public struct Option
{
    public string option;
    public bool isCorrect;
}