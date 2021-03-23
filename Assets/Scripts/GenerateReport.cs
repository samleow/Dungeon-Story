using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Diagnostics;

public class GenerateReport : MonoBehaviour
{
    private Text text;
    GameData _gameData = GameData.getInstance;

    // Start is called before the first frame update
    void Start()
    {
        int totalAnswered, totalCorrect,percent;
        int x = 0;   //position for text label
        int y = 0;    //position for text label
        string result = "";
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");


        for (int i = 0; i < _gameData.report.Count; i = i + 4)
        {
            totalCorrect = int.Parse(_gameData.report[i + 2]);
            totalAnswered = int.Parse(_gameData.report[i + 2]) + int.Parse(_gameData.report[i + 3]);
            percent = totalCorrect * 100 / totalAnswered;
            if (percent >= 80)
            {
                result = "Question: " + _gameData.report[i + 1] + "\n[Difficulty: " + _gameData.report[i] + "]\nTotal Correct Attempts: " + _gameData.report[i + 2] +
                    "           Percentage correct: <color=green>" + percent.ToString() +
                    "%</color>\nTotal Wrong Attempts: " + _gameData.report[i + 3] + "\nTotal Attempts:" + totalAnswered.ToString();
            }
            else if (percent >= 50)
            {
                result = "Question: " + _gameData.report[i + 1] + "\n[Difficulty: " + _gameData.report[i] + "]\nTotal Correct Attempts: " + _gameData.report[i + 2] +
                    "           Percentage correct: <color=orange>" + percent.ToString() +
                    "%</color>\nTotal Wrong Attempts: " + _gameData.report[i + 3] + "\nTotal Attempts:" + totalAnswered.ToString();
            }
            else
            {
                result = "Question: " + _gameData.report[i + 1] + "\n[Difficulty: " + _gameData.report[i] + "]\nTotal Correct Attempts: " + _gameData.report[i + 2] +
                    "           Percentage correct: <color=red>" + percent.ToString() +
                    "%</color>\nTotal Wrong Attempts: " + _gameData.report[i + 3] + "\nTotal Attempts:" + totalAnswered.ToString();
            }
            VerticalLayoutGroup canvasGO = GameObject.Find("Content").GetComponent<VerticalLayoutGroup>();
            GameObject textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();

            // Edit text attribute
            text = textGO.GetComponent<Text>();
            text.text = result;
            text.fontSize = 30;
            text.font = arial;
            text.alignment = TextAnchor.MiddleLeft;
            text.color = Color.white;

            // Positioning and size of text
            RectTransform rectTransform;
            rectTransform = text.GetComponent<RectTransform>();
            //rectTransform.localPosition = new Vector3(x, y, 0);
            rectTransform.sizeDelta = new Vector2(900, 180);
            y = y - 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
