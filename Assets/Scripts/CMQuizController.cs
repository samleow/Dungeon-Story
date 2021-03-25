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
    public QuestionSet currentQuestion;

    public int score = 0;
    public int questionnumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        CMQuestionSet = loadCMQuestions.GetQuestionBank();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateQuestion(){

        int currentQuestionIndex = Random.Range(0, CMQuestionSet.Count);
        
       currentQuestion = CMQuestionSet[currentQuestionIndex];

        questionText.text = currentQuestion.question;
        //Debug.Log(currentQuestion.question);
        option1.text = currentQuestion.options[0];
       // Debug.Log(currentQuestion.options[0]);
        option2.text = currentQuestion.options[1];
        //Debug.Log(currentQuestion.options[1]);
        option3.text = currentQuestion.options[2];
       // Debug.Log(currentQuestion.options[2]);

        //CMQuestionSet.RemoveAt(currentQuestionIndex);
        
    }

    public void CheckAnswer(string option)
    {
        if (option == this.currentQuestion.answer){
            this.score += 1;
        }
        this.questionnumber += 1;
        this.generateQuestion();
    }

    public int getScore(){
        return this.score;
    }

    public int getQuestionNum(){
        return this.questionnumber;
    }
    
}

