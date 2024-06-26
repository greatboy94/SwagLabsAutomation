using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabsAutomation.pageObjects;

public class LoginPage
{
    private IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.Id, Using = "user-name")]
    private IWebElement usernameBy;
    
    [FindsBy(How = How.Id, Using = "password")]
    private IWebElement passwordBy;
    
    [FindsBy(How = How.Id, Using = "login-button")]
    private IWebElement loginButtonBy;
    
    [FindsBy(How = How.XPath, Using = "//h3[@data-test='error']")]
    private IWebElement errorMessageBy;

    public ProductsPage LoginWithCredentials(string username, string password)
    {
        usernameBy.SendKeys(username);
        passwordBy.SendKeys(password);
        loginButtonBy.Click();

        return new ProductsPage(driver);
    }

    public string GetInvalidCredentialsText()
    {
        return errorMessageBy.Text;
    }
}