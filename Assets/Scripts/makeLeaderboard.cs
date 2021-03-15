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
    public Sprite m_Sprite;
    public Image m_Image;
    private Text text;
    GameData _gameData = GameData.getInstance;

    void Start()
    {
        m_Sprite = Resources.Load("UISprite", typeof(Sprite)) as Sprite;
        int x = -220;   //position for text label
        int y = 170;    //position for text label
        var colour = Color.white;
        int rank = 1;   //user rank

        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create canvas
        GameObject canvasGO = GameObject.Find("Canvas");
        /*canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();*/

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        //canvas.renderMode = RenderMode.ScreenSpaceOverlay;
       
        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Edit text attribute
        text = textGO.GetComponent<Text>();
        text.text = "LEADERBOARD";
        text.fontSize = 50;
        text.font = arial;
        text.alignment = TextAnchor.MiddleCenter;

        // Positioning and size of text
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 250, 0);
        rectTransform.sizeDelta = new Vector2(600, 60);

        // Read from preloaded leaderboard
        string path = "Assets/Resources/leaderboard.txt";
        string line;
        
        //Read the text from directly from the leaderboard.txt file
        /*StreamReader reader = new StreamReader(path);
        line = reader.ReadToEnd();        
        string[] nameScores = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        reader.Close();*/

        //print leaderboard
        for (int i = 0; i < 10; i = i + 2)
        {
            //UnityEngine.Debug.Log(nameScores[i]);
            if (string.Compare(_gameData.score[i],_gameData.user)==0)
            {
                
                colour = Color.yellow;
            }
            //disp Rank
            textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();
            text = textGO.GetComponent<Text>();
            if (i != 0 && _gameData.score[i+ 1] == _gameData.score[i- 1])
            {
                text.text = "=";
            }
            else
            {
                text.text = rank.ToString() + ".";
            }

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
            text.text = _gameData.score[i];
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
            text.text = _gameData.score[i+1];
            text.fontSize = 30;
            text.font = arial;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = colour;

            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(x + 400, y, 0);
            rectTransform.sizeDelta = new Vector2(300, 60);
            y = y - 60; // move y position down
            rank++; //increase rank
            colour = Color.white;
        }
        if (PlayerPrefs.GetInt("Rank") > 5)
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

            //disp Rank
            textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();
            text = textGO.GetComponent<Text>();
            text.text = PlayerPrefs.GetInt("Rank").ToString() + ".";
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
            text.text = PlayerPrefs.GetString("Name");
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
            text.text = PlayerPrefs.GetString("Score");
            text.fontSize = 30;
            text.font = arial;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = colour;

            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(x + 400, y, 0);
            rectTransform.sizeDelta = new Vector2(300, 60);
        }
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
