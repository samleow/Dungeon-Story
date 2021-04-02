using NUnit.Framework;
using Altom.AltUnityDriver;

public class Testing
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
    public void TestLoginButton()
    {
	//Here you can write the test
        // Load starting scene
        AltUnityDriver.LoadScene("LandingPage");
        AltUnityDriver.FindObject(By.NAME,"Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("LoginPage");

        // In LoginPage Try login
        AltUnityDriver.FindObject(By.NAME, "login_username").SetText("a");
        AltUnityDriver.FindObject(By.NAME, "login_password").SetText("a");
        AltUnityDriver.FindObject(By.NAME,"Login Button").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("TitlePage");
        
    }


}