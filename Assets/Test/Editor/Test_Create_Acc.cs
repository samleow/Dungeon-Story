using NUnit.Framework;
using Altom.AltUnityDriver;

public class Test_Create_Acc
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
    public void TestCreateAcc()
    {
        //Here you can write the test
        // Load starting scene
        AltUnityDriver.LoadScene("LandingPage");
        AltUnityDriver.FindObject(By.NAME, "Create Account Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("CreateAccountPage");

        // Try Create Account
        AltUnityDriver.FindObject(By.NAME, "create_username").SetText("AutoTesting");
        AltUnityDriver.FindObject(By.NAME, "create_pw").SetText("testing123");
        AltUnityDriver.FindObject(By.NAME, "cfm_pw").SetText("testing123");
        AltUnityDriver.FindObject(By.NAME, "create_email").SetText("autoTest@gmail.com");
        AltUnityDriver.FindObject(By.NAME, "Create Account Button").ClickEvent();
        AltUnityDriver.WaitForObject(By.NAME, "menuCAPopup");
        AltUnityDriver.FindObject(By.NAME, "OK Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("LoginPage");

    }

}
