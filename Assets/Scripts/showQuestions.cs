using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class showQuestions : MonoBehaviour
{
    private Text text;
    public Button btn;
    GameData _gameData = GameData.getInstance;
    QuestionSet qs = new QuestionSet();

    // Start is called before the first frame update
    void Start()
    {
        int x = 0;   //position for text label
        int y = 0;    //position for text label
        string result = "";
        int QID = 0;
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        for (int i = 0; i < 3; i++)
        {
            UnityEngine.Debug.Log("Count" +_gameData.questions[i].Count.ToString());
            for (int j = 0; j < _gameData.questions[i].Count; j++)
            {
                VerticalLayoutGroup canvasGO = GameObject.Find("Content").GetComponent<VerticalLayoutGroup>();
                GameObject textGO = new GameObject();
                textGO.transform.parent = canvasGO.transform;
                textGO.AddComponent<Text>();
                textGO.AddComponent<Button>();
                QID = i * 100 + j;
                textGO.name = QID.ToString();
                //UnityEngine.Debug.Log(QID.ToString());
                btn = GameObject.Find(QID.ToString()).GetComponent<Button>();
                btn.onClick.AddListener(editQues);

                // Edit text attribute
                text = textGO.GetComponent<Text>();
                text.text = _gameData.questions[i][j].question;
                
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
    }

    void editQues()
    {
        int qid = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        
        _gameData.currI = qid / 100;
        _gameData.currJ = qid % 100;
        
        _gameData.currEditQues = _gameData.questions[_gameData.currI][_gameData.currJ];
        _gameData.currQID = _gameData.currEditQues.QID;
        //UnityEngine.Debug.Log(_gameData.currQID);
        SceneManager.LoadScene("editQuesPage");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
