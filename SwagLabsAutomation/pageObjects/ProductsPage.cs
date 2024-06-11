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

    public string[] productsName = { "Sauce Labs Backpack", "Sauce Labs Fleece Jacket" };
    
    
    [FindsBy(How = How.XPath, Using = "//span[@class='title']")]
    private IWebElement productsTitleBy;
    
    [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item']")]
    private IList<IWebElement> inventoryItemsBy;
    
    [FindsBy(How = How.XPath, Using = "(//div[@class='inventory_item_name '])[1]")]
    private IWebElement inventoryItemNameBy;
    
    [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
    private IWebElement oneItemBy;
    
    [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
    private IWebElement countBadgeBy;
  

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

    public void AddToCart()
    {
        oneItemBy.Click();
    }

    public int GetCartBadgeCount()
    {
        int count = 0;
        if (countBadgeBy != null && int.TryParse(countBadgeBy.Text, out count))
        {
            return count;
        }
        return 0;
    }
    
}