using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabsAutomation.pageObjects;

public class CheckoutInfoPage
{
    private IWebDriver driver;

    public CheckoutInfoPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.Id, Using = "first-name")]
    private IWebElement firstNameBy;
    
    [FindsBy(How = How.Id, Using = "last-name")]
    private IWebElement lastNameBy;
    
    [FindsBy(How = How.Id, Using = "postal-code")]
    private IWebElement postalCodeBy;
    
    [FindsBy(How = How.Id, Using = "continue")]
    private IWebElement continueButtonBy;

    public CheckoutOverviewPage FillInfo(string userFirstName, string userLastName, string userPostalCode)
    {
        firstNameBy.SendKeys(userFirstName);
        lastNameBy.SendKeys(userLastName);
        postalCodeBy.SendKeys(userPostalCode);
        continueButtonBy.Click();

        return new CheckoutOverviewPage(driver);
    }
}