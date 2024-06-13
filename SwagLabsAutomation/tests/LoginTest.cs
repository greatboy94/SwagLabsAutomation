using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using SwagLabsAutomation.pageObjects;

namespace SwagLabsAutomation.tests;

[AllureNUnit]
[AllureSuite("Login Suit")]
[AllureFeature("Login Feature")]
public class LoginTest : Base
{
    private string storeProductPageText = "Products";
    private string storeErrorText = "Epic sadface: Username and password do not match any user in this service";
    private string storeLockedOutUserText = "Epic sadface: Sorry, this user has been locked out.";

    [Test]
    [AllureDescription("Verify for valid username and password login")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestValidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        Assert.AreEqual(storeProductPageText, productsPage.GetProductsPageTitle());
    }
    
    [Test]
    [AllureDescription("Verify for invalid username and password login")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetInvalidLoginTestData))]
    public void TestInvalidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);
        
        Assert.AreEqual(storeErrorText, loginPage.GetInvalidCredentialsText());
    }
    
    [Test]
    [AllureDescription("Verify for Locked Out User login")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetLockedOutUserTestData))]
    public void TestLockedOutUserLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);
        
        Assert.AreEqual(storeLockedOutUserText, loginPage.GetInvalidCredentialsText());
    }
}