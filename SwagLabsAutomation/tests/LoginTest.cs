using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using SwagLabsAutomation.pageObjects;

namespace SwagLabsAutomation.tests;

[AllureNUnit]
public class LoginTest : Base
{

    [Test]
    [AllureDescription("Check for valid username and password login")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestValidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);
        Thread.Sleep(5000);
    }
}