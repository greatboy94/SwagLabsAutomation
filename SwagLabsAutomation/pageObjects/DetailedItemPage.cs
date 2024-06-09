using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabsAutomation.pageObjects;

public class DetailedItemPage
{
    private IWebDriver driver;

    public DetailedItemPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//div[@data-test='inventory-item-name']")]
    private IWebElement productNameBy;
    
    [FindsBy(How = How.XPath, Using = "//div[@data-test='inventory_item_desc']")]
    private IWebElement productDescriptionBy;
    
    [FindsBy(How = How.ClassName, Using = "inventory_details_price")]
    private IWebElement productPriceBy;

    public bool VerifyProductDetails()
    {
        return productNameBy.Displayed;
        return productDescriptionBy.Displayed;
        return productPriceBy.Displayed;
    }
    //
    // public bool VerifyProductDescription()
    // {
    //     return productDescriptionBy.Displayed;
    // }
    //
    // public bool VerifyPrice()
    // {
    //     return productPriceBy.Displayed;
    // }
}