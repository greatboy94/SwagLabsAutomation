using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabsAutomation.pageObjects;

public class CheckoutOverviewPage
{
    private IWebDriver driver;

    public CheckoutOverviewPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.Id, Using = "finish")]
    private IWebElement finishButtonBy;

    public CheckoutCompletePage FinishCheckout()
    {
        finishButtonBy.Click();

        return new CheckoutCompletePage(driver);
    }
}