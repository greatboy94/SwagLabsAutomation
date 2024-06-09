using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using SwagLabsAutomation.pageObjects;

namespace SwagLabsAutomation.tests;

[AllureNUnit]
public class ProductsTest : Base
{
    [Test]
    [AllureDescription("Verify Product Count")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestCountInventoryItems(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        int productCount = productsPage.CountInventoryItem();
        Assert.AreEqual(6, productCount);
    }
    
    [Test]
    [AllureDescription("Verify Product Details")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestProductDetails(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        productsPage.ClickToItem();

        DetailedItemPage detailedItemPage = new DetailedItemPage(GetDriver());
        Assert.AreEqual(true, detailedItemPage.VerifyProductDetails());
    }
}