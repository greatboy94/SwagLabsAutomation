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
    
    [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item']")]
    private IList<IWebElement> inventoryItemsBy;
    
    [FindsBy(How = How.XPath, Using = "(//div[@class='inventory_item_name '])[1]")]
    private IWebElement inventoryItemNameBy;

    public string GetProductsPageTitle()
    {
        return productsTitleBy.Text;
    }

    public int CountInventoryItem()
    {
        return inventoryItemsBy.Count;
    }

    public DetailedItemPage ClickToItem()
    {
        inventoryItemNameBy.Click();

        return new DetailedItemPage(driver);
    }
}