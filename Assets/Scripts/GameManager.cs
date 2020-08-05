using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator scoreLabelAnimation;

    public Image timeBar;
    public float totalTime = 10;

    public TMP_Text scoreLabel;

    public TMP_Text questionLabel;
    public TMP_Text[] optionLabel;

    public QuestionData[] questions;

    private int currentQuestionIndex;

    private int currentScore;

    public bool isGameActive;
    public float timer;


    private void Start()
    {
        isGameActive = true;
        scoreLabel.text = "0";
        RestartTimer();

        questionLabel.text = questions[0].question;

        for (int i = 0; i < questions[0].options.Length; i++)
        {
            optionLabel[i].text = questions[0].options[i].option;
        }

    }

    private void Update()
    {
        if (!isGameActive)
            return;

        timer -= Time.deltaTime;

        timeBar.fillAmount = timer / totalTime;

        if(timer < 0)
        {
            NextQuestion();
        }
    }

    private void NextQuestion()
    {
        currentQuestionIndex++;

        if(currentQuestionIndex < questions.Length)
        {
            timeBar.fillAmount = 1.0f;
            questionLabel.text = questions[currentQuestionIndex].question;

            for (int i = 0; i < questions[currentQuestionIndex].options.Length; i++)
            {
                optionLabel[i].text = questions[currentQuestionIndex].options[i].option;
            }
        }
        else
        {
            Debug.Log("Terminamos");
        }
    }

    public void OptionSelected(int index)
    {
        if (questions[currentQuestionIndex].options[index].isCorrect)
        {
            currentScore += 10;
            scoreLabel.text = currentScore.ToString();
            scoreLabelAnimation.SetTrigger("ScoreAnimation");
        }
        else
        {
            currentScore -= 10;
            scoreLabel.text = currentScore.ToString();
        }

        NextQuestion();
    }

    private void RestartTimer()
    {
        timer = totalTime;
        timeBar.fillAmount = 1.0f;
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
