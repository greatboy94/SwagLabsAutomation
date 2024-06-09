using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using SwagLabsAutomation.pageObjects;

namespace SwagLabsAutomation.tests;

[AllureNUnit]
public class LoginTest : Base
{
    private string storeProductPageText = "Products";
    private string storeErrorText = "Epic sadface: Username and password do not match any user in this service";

    [Test]
    [AllureDescription("Check for valid username and password login")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestValidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        Assert.AreEqual(storeProductPageText, productsPage.GetProductsPageTitle());
    }
    
    [Test]
    [AllureDescription("Check for valid username and password login")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetInvalidLoginTestData))]
    public void TestInValidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);
        
        Assert.AreEqual(storeErrorText, loginPage.GetInvalidCredentialsText());
        Thread.Sleep(5000);
    }
}