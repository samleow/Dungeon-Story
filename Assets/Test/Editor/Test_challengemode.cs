using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;
using System.Collections;


public class Test_challengemode
{
    public AltUnityDriver AltUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        AltUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        AltUnityDriver.Stop();
    }

    [Test]
    public void testChallengemode()
    {
	//Here you can write the test
        AltUnityDriver.LoadScene("ChallengeMode");

        var startcanvas = AltUnityDriver.FindObject(By.NAME, "StartCanvas");
        var gameplaycanvas = AltUnityDriver.FindObject(By.NAME, "GameplayCanvas");
        var gameendcanvas = AltUnityDriver.FindObject(By.NAME, "GameEndCanvas");

        Assert.IsTrue(startcanvas.enabled);
        Assert.IsFalse(gameplaycanvas.enabled);
        Assert.IsFalse(gameendcanvas.enabled);

        AltUnityDriver.FindObject(By.NAME,"StartButton").ClickEvent();

        Assert.IsFalse(startcanvas.enabled);
        Assert.IsTrue(gameplaycanvas.enabled);

        var option1 = AltUnityDriver.FindObject(By.NAME, "Option 1");
        var option2 = AltUnityDriver.FindObject(By.NAME, "Option 2");
        var option3 = AltUnityDriver.FindObject(By.NAME, "Option 3");

        int randomTestTimes = Random.Range(0, 15);

        for(int i=0; i<randomTestTimes; i++){
            switch(i){
                case 1:
                option1.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 1", timeout: 3, interval: 1f);
                break;
                case 2:
                option2.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
                case 3:
                option3.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
            }
        }

        var p2startbutton = AltUnityDriver.FindObject(By.NAME, "P2StartButton");
        p2startbutton.ClickEvent();

        for(int i=0; i<randomTestTimes; i++){
            switch(i){
                case 1:
                option1.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 1", timeout: 3, interval: 1f);
                break;
                case 2:
                option2.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
                case 3:
                option3.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
            }

        randomTestTimes = Random.Range(0, 30);

        AltUnityDriver.FindObject(By.NAME,"PlayAgain").ClickEvent();

        AltUnityDriver.FindObject(By.NAME,"thirtyseconds").ClickEvent();

        AltUnityDriver.FindObject(By.NAME,"StartButton").ClickEvent();


        for(i=0; i<randomTestTimes; i++){
            switch(i){
                case 1:
                option1.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 1", timeout: 3, interval: 1f);
                break;
                case 2:
                option2.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
                case 3:
                option3.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
            }
        }

        p2startbutton.ClickEvent();

        for(i=0; i<randomTestTimes; i++){
            switch(i){
                case 1:
                option1.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 1", timeout: 3, interval: 1f);
                break;
                case 2:
                option2.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
                case 3:
                option3.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
            }

        }

        randomTestTimes = Random.Range(0, 60);

        AltUnityDriver.FindObject(By.NAME,"PlayAgain").ClickEvent();

        AltUnityDriver.FindObject(By.NAME,"sixtyseconds").ClickEvent();

        AltUnityDriver.FindObject(By.NAME,"StartButton").ClickEvent();


        for(i=0; i<randomTestTimes; i++){
            switch(i){
                case 1:
                option1.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 1", timeout: 3, interval: 1f);
                break;
                case 2:
                option2.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
                case 3:
                option3.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
            }
        }

        p2startbutton.ClickEvent();

        for(i=0; i<randomTestTimes; i++){
            switch(i){
                case 1:
                option1.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 1", timeout: 3, interval: 1f);
                break;
                case 2:
                option2.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
                case 3:
                option3.ClickEvent();
                AltUnityDriver.WaitForObject(By.NAME,"Option 2", timeout: 3, interval: 1f);
                break;
            }

        }




    }

    }
}