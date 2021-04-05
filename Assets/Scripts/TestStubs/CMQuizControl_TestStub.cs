using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class test : MonoBehaviour
{

    CMQuizController CMQuizController = new CMQuizController();
    int test_score = 10;
    int test_questionnum = 15;


    // Start is called before the first frame update
    void Start()
    {
        CMQuizController.setScore(test_score);
        CMQuizController.setQuestionNum(test_questionnum);
        Assert.AreEqual(test_score,CMQuizController.getScore());
        Assert.AreEqual(test_questionnum,CMQuizController.getQuestionNum());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
