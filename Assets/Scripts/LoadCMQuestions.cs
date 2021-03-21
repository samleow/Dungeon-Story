using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadCMQuestions : MonoBehaviour
{
    private CMQuizController quizcontroller;
    private ChallengeModeManager cmManager;
    public List<QuestionSet> CMQuestionSet = new List<QuestionSet>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading CM Questions");
        StartCoroutine(loadQuestions());

    }

IEnumerator loadQuestions()
    {
        string[] questionBank = new string[] {};
        UnityWebRequest www = UnityWebRequest.Get("http://valerianlow123.000webhostapp.com/getQuestions.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            questionBank = www.downloadHandler.text.Split(',', '\n');
            //Debug.Log(questionBank.Length).ToString;   
        }

            int i = 0;
            int diff1, diff2, diff3;
            diff1 = int.Parse(questionBank[i]);
            diff2 = int.Parse(questionBank[++i]);
            diff3 = int.Parse(questionBank[++i]);
            UnityEngine.Debug.Log(diff1);
            UnityEngine.Debug.Log(diff2);
            UnityEngine.Debug.Log(diff3);
            int j = 0;
            //_gameData.questions.Add(newSet);
            while (j < (diff1+diff2+diff3))
            {
                QuestionSet qs = new QuestionSet();
                qs.question = questionBank[++i];
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.answer = questionBank[++i];
                qs.QID = int.Parse(questionBank[++i]);
                CMQuestionSet.Add(qs);
                j++;
            }
            
            //PassDataBank();
            Debug.Log("CM Questions Loaded");
            //Debug.Log(CMQuestionSet[0].question);
    }

//pass databank to CMquizController
    //  void PassDataBank(){
    //     quizcontroller = GameObject.FindObjectOfType<CMQuizController>();
    //     quizcontroller.UpdateDatabank(CMQuestionSet);

    //     // cmManager = GameObject.FindObjectOfType<ChallengeModeManager>();
    //     // cmManager.UpdateDatabank(CMQuestionSet);

    // }

    public List<QuestionSet> GetQuestionBank(){
        return this.CMQuestionSet;
    }
}
