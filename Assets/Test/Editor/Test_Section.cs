using NUnit.Framework;
using Altom.AltUnityDriver;

public class Test_Section
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
    public void TestLoadGame()
    {
        // Load starting scene
        AltUnityDriver.LoadScene("LandingPage");
        AltUnityDriver.FindObject(By.NAME, "Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("LoginPage");

        // In LoginPage Try login
        AltUnityDriver.FindObject(By.NAME, "login_username").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "login_password").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("TitlePage");

        AltUnityDriver.FindObject(By.NAME, "Start Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("PlayModePage");

        AltUnityDriver.FindObject(By.NAME, "DungeonMode Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("WorldPage");
        

        AltUnityDriver.FindObject(By.NAME, "World1").ClickEvent();
        var altElement = AltUnityDriver.WaitForObjectWithText(By.NAME, "world1Text", "SDLC");
        AltUnityDriver.WaitForCurrentSceneToBe("SectionPage");

        AltUnityDriver.FindObject(By.NAME, "Section 1 Button").ClickEvent();
        var altElement2 = AltUnityDriver.WaitForObjectWithText(By.NAME, "Section 1 Button", "Specifications/Requirements");
        AltUnityDriver.WaitForCurrentSceneToBe("CharacterPage");

        AltUnityDriver.FindObject(By.NAME, "Warrior").ClickEvent();
        AltUnityDriver.FindObject(By.NAME, "Confirm Button").ClickEvent();

        AltUnityDriver.WaitForCurrentSceneToBe("DoorPage");

        GameData gd = GameData.getInstance;
        Assert.AreEqual(gd.player_class_name, "Warrior");

    }

}
