using NUnit.Framework;
using Altom.AltUnityDriver;

public class Test_PlayMode
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
    public void Test_PlayModeButton()
    {
	//Here you can write the test
    // PlayMode Related Functioanlity 
    // Load Dungeon Mode
    AltUnityDriver.LoadScene("PlayModePage");
    AltUnityDriver.FindObject(By.NAME, "DungeonMode Button").ClickEvent();
    AltUnityDriver.WaitForCurrentSceneToBe("WorldPage");

    // Back
    AltUnityDriver.FindObject(By.NAME, "Back Button").ClickEvent();
    AltUnityDriver.WaitForCurrentSceneToBe("PlayModePage");

    // Load Challenge Mode
    AltUnityDriver.FindObject(By.NAME, "ChallengeMode Button").ClickEvent();
    AltUnityDriver.WaitForCurrentSceneToBe("ChallengeMode");

    // Back
    AltUnityDriver.FindObject(By.NAME, "Return (1)").ClickEvent();
    AltUnityDriver.WaitForCurrentSceneToBe("PlayModePage");

    // popup
    //var dm_popup = AltUnityDriver.FindObject(By.NAME, "Dungeon Help Popup");
    //var cm_popup = AltUnityDriver.FindObject(By.NAME, "Challenge Help Popup");
    
    AltUnityDriver.FindObject(By.NAME, "DM help Button").ClickEvent();
    AltUnityDriver.FindObject(By.NAME, "Button").ClickEvent();

    AltUnityDriver.FindObject(By.NAME, "CM help Button").ClickEvent();
    AltUnityDriver.FindObject(By.NAME, "Button").ClickEvent();
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

        AltUnityDriver.WaitForCurrentSceneToBe("SectionPage");

        AltUnityDriver.WaitForObject(By.NAME, "Section 1 Button", timeout: 5, interval: 2.5f);

        AltUnityDriver.FindObject(By.NAME, "Section 1 Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("CharacterPage");

        AltUnityDriver.FindObject(By.NAME, "Warrior").ClickEvent();
        AltUnityDriver.FindObject(By.NAME, "Confirm Button").ClickEvent();

        AltUnityDriver.WaitForCurrentSceneToBe("DoorPage");

        GameData gd = GameData.getInstance;
        Assert.AreEqual(gd.player_class_name, "Warrior");

    }

}