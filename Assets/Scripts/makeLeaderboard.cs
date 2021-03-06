using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class makeLeaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;

    void Start()
    { 
        int x = -220;   //position for text label
        int y = 170;    //position for text label

        int rank = 1;   //user rank

        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create canvas
        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Create text 
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
        StreamReader reader = new StreamReader(path);
        line = reader.ReadToEnd();
        string[] nameScores = line.Split('\n');
        reader.Close();

        //print leaderboard
        for (int i = 0; i < nameScores.Length - 1; i = i + 2)
        {
            //disp Rank
            textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();
            text = textGO.GetComponent<Text>();
            if (i != 0 && nameScores[i + 1] == nameScores[i - 1])
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

            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(x, y, 0);
            rectTransform.sizeDelta = new Vector2(50, 60);

            //disp Name
            textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();
            text = textGO.GetComponent<Text>();
            text.text = nameScores[i];
            text.fontSize = 30;
            text.font = arial;
            text.alignment = TextAnchor.MiddleLeft;

            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(x + 200, y, 0);
            rectTransform.sizeDelta = new Vector2(300, 60);

            //disp Score
            textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();
            text = textGO.GetComponent<Text>();
            text.text = nameScores[i + 1];
            text.fontSize = 30;
            text.font = arial;
            text.alignment = TextAnchor.MiddleCenter;

            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(x + 400, y, 0);
            rectTransform.sizeDelta = new Vector2(300, 60);
            y = y - 60; // move y position down
            rank++; //increase rank
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
