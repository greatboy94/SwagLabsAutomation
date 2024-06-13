using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using SwagLabsAutomation.pageObjects;

namespace SwagLabsAutomation.tests;

[AllureNUnit]
[AllureSuite("Product Functionality")]
[Parallelizable(ParallelScope.Children)]
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
    
    [Test]
    [AllureDescription("Verify Item Added To Cart")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestAddToCart(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        productsPage.AddToCart();
        Assert.AreEqual(1, productsPage.GetCartBadgeCount(), "The cart badge count should be 1.");
    }
    
    [Test]
    [AllureDescription("Verify Item Removed from Cart")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestRemoveFromCart(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        productsPage.RemoveItemFromCart();
        Assert.AreEqual(0, productsPage.GetCartBadgeCount(), "The cart badge count should be 0.");
    }
    
    [Test]
    [AllureDescription("Verify Sort Functionality")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestSortItems(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        Assert.AreNotEqual(productsPage.BeforeSorting(), productsPage.AfterSorting());
    }
    
    [Test]
    [AllureDescription("Verify Sidebar Menu")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestSidebarMenu(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        productsPage.ClickToSidebarMenu();
        WaitForElementIsVisible(By.Id("inventory_sidebar_link"));
        Assert.IsTrue(productsPage.AreAllSidebarMenuOptionsDisplayed());
    }
    
    [Test]
    [AllureDescription("Verify Item Images visible")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestItemImages(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        Assert.IsTrue(productsPage.AreAllProductImagesDisplayed());
    }
}