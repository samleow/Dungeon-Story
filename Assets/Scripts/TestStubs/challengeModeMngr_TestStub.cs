using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions;

public class challengeModeMngr_Test : MonoBehaviour
{
    ChallengeModeManager challengeModeManager = new ChallengeModeManager();

    int testscore = 5;
    int testquestionnum = 10;

    int testaccuracy;
    int actualaccuracy;

    float test_currentTime, test_startingTime;
    int test_player2score, test_player2questionnum;
    int test_player1score,test_player1questionNum;

    // Start is called before the first frame update
    void Start()
    {
        testaccuracy = (int)Math.Round((double)(100 * testscore) / testquestionnum);
        actualaccuracy = challengeModeManager.accuracyCalculator(testscore,testquestionnum);

        test_currentTime = 10f;
        test_startingTime= 0f;

        test_player2score = 10;
        test_player2questionnum = 15;

        test_player1score = 10;
        test_player1questionNum = 15;

        challengeModeManager.currentTime = test_currentTime;
        challengeModeManager.startingTime = test_startingTime;

        challengeModeManager.player1score = test_player1score;
        challengeModeManager.player1questionNum = test_player1questionNum;

        challengeModeManager.player2score = test_player2score;
        challengeModeManager.player2questionNum = test_player2questionnum;

        checkAssert();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkAssert(){

        Assert.AreEqual(testaccuracy,actualaccuracy);
        
        Assert.AreEqual(test_currentTime, challengeModeManager.currentTime);
        Assert.AreEqual(test_startingTime, challengeModeManager.startingTime);

        Assert.AreEqual(test_player1score,challengeModeManager.player1score);
        Assert.AreEqual(test_player1questionNum,challengeModeManager.player1questionNum);

        Assert.AreEqual(test_player2score,challengeModeManager.player2score);
        Assert.AreEqual(test_player2questionnum,challengeModeManager.player2questionNum);

    }
}
