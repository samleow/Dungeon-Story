using NUnit.Framework;
using Altom.AltUnityDriver;

public class Test_AddQuestion
{
    public AltUnityDriver AltUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        AltUnityDriver = new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        AltUnityDriver.Stop();
    }

    [Test]
    public void TestAddQuestion()
    {
        //Here you can write the test
        // Load starting scene
        AltUnityDriver.LoadScene("AddQuesPage");

        // In LoginPage Try login
        AltUnityDriver.FindObject(By.NAME, "Question").SetText("testing question");
        AltUnityDriver.FindObject(By.NAME, "Option1").SetText("option 1");
        AltUnityDriver.FindObject(By.NAME, "Option2").SetText("option 2");
        AltUnityDriver.FindObject(By.NAME, "Option3").SetText("option 3");
        AltUnityDriver.FindObject(By.NAME, "Answer").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "Difficulty").SetText("1");
        AltUnityDriver.FindObject(By.NAME, "Save").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("AddQuesPage");

    }

}
