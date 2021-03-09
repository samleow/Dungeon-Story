using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    // List of questions and answer options
    public List<QuestionSet> questions = new List<QuestionSet>();
    int question_current = -1;
    public GameObject QuestionMenu = null;

    // Start is called before the first frame update
    void Start()
    {
        if(QuestionMenu.activeSelf)
            QuestionMenu.SetActive(false);

        // Extract questions and answer options from question bank and store into list here
        // TODO

        // temporary hardcoded qns as template after getting from qn bank
        // can use for loop to iterate through qns
        QuestionSet q1 = new QuestionSet();
        q1.question = "1 + 1 = ?";
        q1.answer = 2;
        q1.difficulty = 1;
        q1.time_to_answer = 25;
        q1.options.Add("0");
        q1.options.Add("1");
        q1.options.Add("2");
        q1.options.Add("3");
        questions.Add(q1);

        // set question number/counter
        question_current = 0;
        // set question set into quiz controller
        QuestionMenu.GetComponent<QuizController>().questionSet = questions[question_current];
        // set qn screen on
        // can do fade in or animations before transition
        StartCoroutine(SetQnScreen(true,1));
    }

    // Update is called once per frame
    /*void Update()
    {
        // TODO
    }*/

    // TODO implement fade in/out for question screen
    IEnumerator SetQnScreen(bool active, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (QuestionMenu)
            QuestionMenu.SetActive(active);
    }



}
