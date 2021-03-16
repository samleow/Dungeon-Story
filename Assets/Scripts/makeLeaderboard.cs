using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class makeLeaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasGO;
    public GameObject textGO;
    public Canvas canvas;
    public Font arial;
    public RectTransform rectTransform;
    public bool outputUser = false;
    private Text text;
    GameData _gameData = GameData.getInstance;
    public int rank = 1;   //user rank
    public Color colour = Color.white;

    void Start()
    {
        
        int tempScore, tempScore2;
        string tempUser;
        int i = 0;
        int x = -220;   //position for text label
        int y = 170;    //position for text label       
                
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create canvas
        canvasGO = GameObject.Find("Canvas");

        // Get canvas from the GameObject.        
        canvas = canvasGO.GetComponent<Canvas>();
       
        textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Edit text attribute
        text = textGO.GetComponent<Text>();
        text.text = "LEADERBOARD";
        text.fontSize = 50;
        text.font = arial;
        text.alignment = TextAnchor.MiddleCenter;

        // Positioning and size of text        
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 250, 0);
        rectTransform.sizeDelta = new Vector2(600, 60);        

        //print leaderboard
        for (i = 0; i < 10; i = i + 2)
        {
            tempUser = _gameData.score[i];
            tempScore = int.Parse(_gameData.score[i + 1]);
            if (tempScore == _gameData.high_score && !tempUser.Equals(_gameData.user) && outputUser == false)
            {
                outputDetails(x, y, _gameData.user, _gameData.high_score, -1, rank, Color.yellow);
                y = y - 60;
            }
            if (i > 0)
            {
                tempScore2 = int.Parse(_gameData.score[i - 1]);
            }
            else
            {
                tempScore2 = -1;
            }
            outputDetails(x, y, tempUser, tempScore, tempScore2, rank, colour);
           

            y = y - 60; // move y position down
            rank++; //increase rank
            colour = Color.white;
        }
        if (_gameData.rank > 5 && outputUser==false)
        {
            // ...
            textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();
            text = textGO.GetComponent<Text>();
            text.text = ".\n.\n.";
            text.fontSize = 30;
            text.font = arial;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = colour;

            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, y-10, 0);
            rectTransform.sizeDelta = new Vector2(50, 120);

            y = y - 80;
            colour = Color.yellow;
            outputDetails(x, y, _gameData.user, _gameData.high_score, -1, _gameData.rank, colour);
        }
    }
    
    void outputDetails(int x, int y,string name, int score, int score2, int rank, Color colour)
    {
      
        if (string.Compare(name, _gameData.user) == 0)
        {
            outputUser = true;
            colour = Color.yellow;
        }
        //disp Rank
        textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();
        text = textGO.GetComponent<Text>();
        if (score == score2 || (score== _gameData.high_score && !name.Equals(_gameData.user)))
        {
            text.text = "=";
        }
        else
        {
            text.text = rank.ToString() + ".";
        }
        //disp Rank
      
        text.fontSize = 30;
        text.font = arial;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = colour;

        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(x, y, 0);
        rectTransform.sizeDelta = new Vector2(50, 60);

        //disp Name
        textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();
        text = textGO.GetComponent<Text>();
        text.text = name;
        text.fontSize = 30;
        text.font = arial;
        text.alignment = TextAnchor.MiddleLeft;
        text.color = colour;

        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(x + 200, y, 0);
        rectTransform.sizeDelta = new Vector2(300, 60);

        //disp Score
        textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();
        text = textGO.GetComponent<Text>();
        text.text = score.ToString();
        text.fontSize = 30;
        text.font = arial;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = colour;

        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(x + 400, y, 0);
        rectTransform.sizeDelta = new Vector2(300, 60);
        
    }
    void goBack()
    {
        SceneManager.LoadScene("TitlePage");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
