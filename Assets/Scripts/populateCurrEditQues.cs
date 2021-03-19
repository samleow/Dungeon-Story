using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class populateCurrEditQues : MonoBehaviour
{
    public Text textField;
    GameData _gameData = GameData.getInstance;

    // Start is called before the first frame update
    void Start()
    {
        InputField quesField = GameObject.Find("Question").GetComponent<InputField>();
        InputField option1Field = GameObject.Find("option1").GetComponent<InputField>();
        InputField option2Field = GameObject.Find("option2").GetComponent<InputField>();
        InputField option3Field = GameObject.Find("option3").GetComponent<InputField>();
        InputField answerField = GameObject.Find("answer").GetComponent<InputField>();
        InputField difficultyField = GameObject.Find("difficulty").GetComponent<InputField>();
        quesField.text = _gameData.currEditQues.question;
        option1Field.text = _gameData.currEditQues.options[0];
        option2Field.text = _gameData.currEditQues.options[1];
        option3Field.text = _gameData.currEditQues.options[2];
        answerField.text = _gameData.currEditQues.answer;
        difficultyField.text = _gameData.currEditQues.difficulty.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
