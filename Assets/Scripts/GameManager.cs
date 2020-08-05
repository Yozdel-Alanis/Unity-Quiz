using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image timeBar;
    public float totalTime = 10;

    public TMP_Text scoreLabel;

    public TMP_Text questionLabel;
    public TMP_Text[] optionLabel;

    public QuestionData[] questions;

    private int currentQuestionIndex;

    private void Start()
    {
        scoreLabel.text = "0";

        questionLabel.text = questions[0].question;

        for (int i = 0; i < questions[0].options.Length; i++)
        {
            optionLabel[i].text = questions[0].options[i].option;
        }

    }

    private void Update()
    {
        timeBar.fillAmount -= Time.deltaTime / totalTime;
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;

        questionLabel.text = questions[currentQuestionIndex].question;

        for (int i = 0; i < questions[currentQuestionIndex].options.Length; i++)
        {
            optionLabel[i].text = questions[currentQuestionIndex].options[i].option;
        }
    }

    public void OptionSelected(int index)
    {
        Debug.Log("Button " + index + "was selected");
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
