using SwagLabsAutomation.pageObjects;

namespace SwagLabsAutomation.tests;

public class LoginTest : Base
{

    [Test]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void ValidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);
        Thread.Sleep(5000);
    }
}