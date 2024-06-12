using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SwagLabsAutomation;

public class Base
{
    public IWebDriver driver;
    private AllureLifecycle allure;
    
    [SetUp]
    public void Setup()
    {

        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.saucedemo.com");
        
        allure = AllureLifecycle.Instance;
    }

    public IWebDriver GetDriver()
    {
        return driver;
    }
    
    protected void WaitForElementIsVisible(By locator)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    protected void WaitForElementToBeClickable(By locator)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
        driver.Quit();
    }
}