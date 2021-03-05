using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class makeLeaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;

    void Start()
    {
        //SceneManager.LoadScene("LeaderboardPage");    
    
        StartCoroutine(loadLeaderboard());

    }
    IEnumerator loadLeaderboard()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://valerianlow123.000webhostapp.com/getLeaderboard.php");
        //WWW getScores = new WWW("http://valerianlow123.000webhostapp.com/getLeaderboard.php?");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            //Debug.Log(www.error);
        }
        else
        {            
            string [] nameScores = www.downloadHandler.text.Split(' ');
            Debug.Log(nameScores[8]);
            //yield return nameScores;
            //SceneManager.LoadScene("LeaderboardPage");    
            int x = -220;
            int y = 170;

            int rank = 1;

            Font arial;
            arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

            GameObject canvasGO = new GameObject();
            canvasGO.name = "Canvas";
            canvasGO.AddComponent<Canvas>();
            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();

            // Get canvas from the GameObject.
            Canvas canvas;
            canvas = canvasGO.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            GameObject textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();

            text = textGO.GetComponent<Text>();
            text.text = "LEADERBOARD";
            text.fontSize = 50;
            text.font = arial;
            text.alignment = TextAnchor.MiddleCenter;

            RectTransform rectTransform;
            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 250, 0);
            rectTransform.sizeDelta = new Vector2(600, 60);
            //Console.WriteLine(nameScores[0]);
            for (int i = 0; i < nameScores.Length-1; i = i + 2)
            {
                //disp Rank
                if(i!=0 && nameScores[i+1] != nameScores[i-1])
                {
                    rank++;
                }
                textGO = new GameObject();
                textGO.transform.parent = canvasGO.transform;
                textGO.AddComponent<Text>();

                text = textGO.GetComponent<Text>();
                text.text = rank.ToString() + ".";
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
                text.alignment = TextAnchor.MiddleCenter;

                rectTransform = text.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(x+100, y, 0);
                rectTransform.sizeDelta = new Vector2(300, 60);
                //disp Score
                textGO = new GameObject();
                textGO.transform.parent = canvasGO.transform;
                textGO.AddComponent<Text>();

                text = textGO.GetComponent<Text>();
                text.text = nameScores[i+1];
                text.fontSize = 30;
                text.font = arial;
                text.alignment = TextAnchor.MiddleCenter;

                rectTransform = text.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(x + 400, y, 0);
                rectTransform.sizeDelta = new Vector2(300, 60);
                y = y - 60;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
