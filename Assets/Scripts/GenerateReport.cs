using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateReport : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        int x = 0;   //position for text label
        int y = 0;    //position for text label
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        for (int i = 0; i < 10; i++)
        {
            VerticalLayoutGroup canvasGO = GameObject.Find("Content").GetComponent<VerticalLayoutGroup>();
            GameObject textGO = new GameObject();
            textGO.transform.parent = canvasGO.transform;
            textGO.AddComponent<Text>();

            // Edit text attribute
            text = textGO.GetComponent<Text>();
            text.text = "LEADERBOARD";
            text.fontSize = 35;
            text.font = arial;
            text.alignment = TextAnchor.MiddleLeft;

            // Positioning and size of text
            RectTransform rectTransform;
            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(x, y, 0);
            rectTransform.sizeDelta = new Vector2(900, 60);
            y = y - 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
