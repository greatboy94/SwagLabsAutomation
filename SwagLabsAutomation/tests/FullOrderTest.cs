using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using SwagLabsAutomation.pageObjects;

namespace SwagLabsAutomation.tests;

[AllureNUnit]
[AllureSuite("Full Order Functionality")]
public class FullOrderTest : Base
{
    [Test]
    [AllureDescription("Verify Whole Order Item Flow")]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void TestValidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWithCredentials(username, password);

        ProductsPage productsPage = new ProductsPage(GetDriver());
        productsPage.AddItemToCart();

        YourCartPage yourCartPage = new YourCartPage(GetDriver());
        WaitForElementIsVisible(By.Id("checkout"));
        yourCartPage.CheckoutItem();

        CheckoutInfoPage checkoutInfoPage = new CheckoutInfoPage(GetDriver());
        WaitForElementIsVisible(By.Id("continue"));
        checkoutInfoPage.FillInfo("Damon", "Sal", "140110");

        CheckoutOverviewPage checkoutOverviewPage = new CheckoutOverviewPage(GetDriver());
        WaitForElementIsVisible(By.Id("finish"));
        checkoutOverviewPage.FinishCheckout();

        CheckoutCompletePage checkoutCompletePage = new CheckoutCompletePage(GetDriver());
        WaitForElementIsVisible(By.ClassName("complete-header"));
        Assert.AreEqual("Thank you for your order!", checkoutCompletePage.GetCompleteText());
    }
}