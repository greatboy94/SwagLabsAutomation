using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabsAutomation.pageObjects;

public class ProductsPage
{
    private IWebDriver driver;

    public ProductsPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//span[@class='title']")]
    private IWebElement productsTitleBy;

    public string GetProductsPageTitle()
    {
        return productsTitleBy.Text;
    }
}