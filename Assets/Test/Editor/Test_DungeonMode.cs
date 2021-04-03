using NUnit.Framework;
using Altom.AltUnityDriver;
using System.Threading;

public class Test_DungeonMode
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
    public void TestLoadGame()
    {
        GameData gd = GameData.getInstance;
        // Load starting scene
        AltUnityDriver.LoadScene("LandingPage");
        AltUnityDriver.FindObject(By.NAME, "Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("LoginPage");

        AltUnityDriver.FindObject(By.NAME, "login_username").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "login_password").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("TitlePage");

    }

    [Test]
    public void TestVictory()
    {
        //GameData gd = GameData.getInstance;
        // Load starting scene
        AltUnityDriver.LoadScene("LandingPage");
        AltUnityDriver.FindObject(By.NAME, "Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("LoginPage");

        AltUnityDriver.FindObject(By.NAME, "login_username").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "login_password").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("TitlePage");

        AltUnityDriver.FindObject(By.NAME, "Start Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("PlayModePage");

        AltUnityDriver.FindObject(By.NAME, "DungeonMode Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("WorldPage");

        AltUnityDriver.LoadScene("SectionPage");
        AltUnityDriver.FindObject(By.NAME, "Section 1 Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("CharacterPage");

        AltUnityDriver.FindObject(By.NAME, "Warrior").ClickEvent();
        AltUnityDriver.FindObject(By.NAME, "Confirm Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("DoorPage");

        AltUnityDriver.FindObject(By.NAME, "Door 2 Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("BattlePage");

        AltUnityDriver.WaitForObject(By.NAME, "QuestionsCanvas");
        AltUnityObject questionsCanvas = AltUnityDriver.FindObject(By.NAME, "QuestionsCanvas");
        string answer = questionsCanvas.GetComponentProperty("QuizController", "questionSet.answer");

        questionsCanvas.CallComponentMethod("QuizController", "SelectedOption", answer);

        //AltUnityDriver.FindObject(By.NAME, "Option_1").ClickEvent();
        Thread.Sleep(1000);

        AltUnityDriver.WaitForObject(By.NAME, "QuestionsCanvas");
        questionsCanvas = AltUnityDriver.FindObject(By.NAME, "QuestionsCanvas");
        answer = questionsCanvas.GetComponentProperty("QuizController", "questionSet.answer");

        questionsCanvas.CallComponentMethod("QuizController", "SelectedOption", answer);

        Thread.Sleep(1000);

        AltUnityDriver.WaitForObject(By.NAME, "QuestionsCanvas");
        questionsCanvas = AltUnityDriver.FindObject(By.NAME, "QuestionsCanvas");
        answer = questionsCanvas.GetComponentProperty("QuizController", "questionSet.answer");

        questionsCanvas.CallComponentMethod("QuizController", "SelectedOption", answer);

        Thread.Sleep(1000);

        AltUnityDriver.WaitForObject(By.NAME, "QuestionsCanvas");
        questionsCanvas = AltUnityDriver.FindObject(By.NAME, "QuestionsCanvas");
        answer = questionsCanvas.GetComponentProperty("QuizController", "questionSet.answer");

        questionsCanvas.CallComponentMethod("QuizController", "SelectedOption", answer);
    }

}