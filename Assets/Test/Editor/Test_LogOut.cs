using NUnit.Framework;
using Altom.AltUnityDriver;

public class Test_LogOut
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
    public void TestLogOut()
    {
        AltUnityDriver.LoadScene("TitlePage");
        AltUnityDriver.FindObject(By.NAME, "Quit Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("LandingPage");
    }

}