using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabsAutomation.pageObjects;

public class CheckoutCompletePage
{
    private IWebDriver driver;

    public CheckoutCompletePage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.ClassName, Using = "complete-header")]
    private IWebElement completeTextBy;

    public string GetCompleteText()
    {
        return completeTextBy.Text;
    }
}