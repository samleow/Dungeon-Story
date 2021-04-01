using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieChart : MonoBehaviour
{
    // initialise variable
    float[] values = new float[2];
    public Color[] wedgeColors;
    public Image wedgePrefab;
    float totalAnswered, totalCorrect, totalWrong, correctPercent, wrongPercent;

    // Get Report Relevant Information
    private Text text;
    GameData _gameData = GameData.getInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get Data, need to open from admin page to get gamedata preload leaderboard
        for (int i = 0; i < _gameData.report.Count; i = i + 4)
        {
            totalCorrect += float.Parse(_gameData.report[i + 2]);
            totalWrong += float.Parse(_gameData.report[i + 3]);
            totalAnswered += float.Parse(_gameData.report[i + 2]) + float.Parse(_gameData.report[i + 3]);
        }

        values[0] = totalCorrect;
        values[1] = totalWrong;

        // Generate Graph by calling Graph Function
        MakeGraph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeGraph()
    {
        // initialise variable
        float zRotation = 0f;

        // For Loop to generate graph
        for(int i = 0; i < wedgeColors.Length; i++)
        {
            Image newWedge = Instantiate(wedgePrefab) as Image;
            newWedge.transform.SetParent(transform, false);
            newWedge.color = wedgeColors[i];
            newWedge.fillAmount = values[i] / totalAnswered;
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= newWedge.fillAmount * 360f;
        }

        // Compute and Display values
        correctPercent = totalCorrect * 100 / totalAnswered;
        wrongPercent = totalWrong * 100 / totalAnswered;

        Text correctAnswer = GameObject.Find("Canvas/CorrectAnswer").GetComponent<Text>();
        correctAnswer.text = correctPercent.ToString() + " %";

        Text wrongAnswer = GameObject.Find("Canvas/WrongAnswer").GetComponent<Text>();
        wrongAnswer.text = wrongPercent.ToString() + " %";
    }
}
