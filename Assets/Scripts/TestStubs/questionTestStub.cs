using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;


public class questionTestStub : MonoBehaviour
{
    QuestionSet questionset = new QuestionSet();
    string testquestion = "Test Question";
    string testanswer = "a";
    int testdifficulty = 1;
    int testqid = 1;

        void Start()
    {
        questionset.question = "Test Question";
        questionset.answer = "a";
        questionset.difficulty = 1;
        questionset.QID = 1;
        checkAssert();
    }

    void checkAssert(){
        Assert.AreEqual(testquestion, questionset.question);
        Assert.AreEqual(testanswer, questionset.answer);
        Assert.AreEqual(testdifficulty, questionset.difficulty);
        Assert.AreEqual(testqid, questionset.QID);
    }

}
