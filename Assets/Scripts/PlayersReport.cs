using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayersReport : MonoBehaviour
{
    // Start is called before the first frame update
    GameData _gameData;
    void Start()
    {
        _gameData = GameData.getInstance;
        Text text = GameObject.Find("total_answered").GetComponent<Text>();
        Text text1 = GameObject.Find("total_correct").GetComponent<Text>();
        Text text2 = GameObject.Find("total_wrong").GetComponent<Text>();
        Text text3 = GameObject.Find("total_score").GetComponent<Text>();
        text.text = _gameData.total_questions.ToString();
        text1.text = _gameData.questions_correct.ToString();
        text2.text = _gameData.questions_wrong.ToString();
        text3.text = _gameData.score_current.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
