using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CMQuizController : MonoBehaviour
{
    public LoadCMQuestions loadCMQuestions;
    public Text questionText = null;
    public Text option1 = null;
    public Text option2 = null;
    public Text option3 = null;
    public List<QuestionSet> CMQuestionSet = new List<QuestionSet>();
    // Start is called before the first frame update
    void Start()
    {
        CMQuestionSet = loadCMQuestions.GetQuestionBank();
        //Debug.Log(CMQuestionSet[0]);
        //generateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateQuestion(){
       QuestionSet currentQuestion = CMQuestionSet[Random.Range(0, CMQuestionSet.Count)];

        questionText.text = currentQuestion.question;
        Debug.Log(currentQuestion.question);
        option1.text = currentQuestion.options[0];
        Debug.Log(currentQuestion.options[0]);
        option2.text = currentQuestion.options[1];
        Debug.Log(currentQuestion.options[1]);
        option3.text = currentQuestion.options[2];
        Debug.Log(currentQuestion.options[2]);
    }

    public void SetQuestionSet(List<QuestionSet> _questionset){
        _questionset = CMQuestionSet;
    }

    
}

