using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabsAutomation.pageObjects;

public class YourCartPage
{
    private IWebDriver driver;

    public YourCartPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.Id, Using = "checkout")]
    private IWebElement checkoutButtonBy;

    public CheckoutInfoPage CheckoutItem()
    {
        checkoutButtonBy.Click();

        return new CheckoutInfoPage(driver);
    }
}