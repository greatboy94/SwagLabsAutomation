using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SwagLabsAutomation;

public class Base
{
    //public IWebDriver driver;
    public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
    private AllureLifecycle allure;
    
    [SetUp]
    public void Setup()
    {

        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver.Value = new ChromeDriver();
        
        driver.Value.Manage().Window.Maximize();
        driver.Value.Navigate().GoToUrl("https://www.saucedemo.com");
        
        allure = AllureLifecycle.Instance;
    }

    public IWebDriver GetDriver()
    {
        return driver.Value;
    }
    
    protected void WaitForElementIsVisible(By locator)
    {
        WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    protected void WaitForElementToBeClickable(By locator)
    {
        WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
    }
    
    public static JsonReader GetDataParser()
    {
        return new JsonReader();
    }
    
    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status==TestStatus.Failed)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

            allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
        }
        driver.Value.Quit();
    }
}