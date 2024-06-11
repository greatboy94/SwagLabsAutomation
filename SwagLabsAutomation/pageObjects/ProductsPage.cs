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
    
    [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
    private IWebElement removeButtonBy;
    
    [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item_name']")]
    private IList<IWebElement> allItemNameBy;
    
    private readonly By removeButtonBy2 = By.XPath("//button[contains(text(),'Remove')]");
    
  

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
        try
        {
            int count = 0;
            if (countBadgeBy != null && int.TryParse(countBadgeBy.Text, out count))
            {
                return count;
            }
        }
        catch (NoSuchElementException)
        {
            return 0;   // If the badge is not present, assume zero items in the cart
        }
        catch (FormatException)
        {
            return 0;   // If the badge text is not a valid number, assume zero items in the cart
        }
        return 0;
    }

    public void RemoveItemFromCart()
    {
        oneItemBy.Click();
        removeButtonBy.Click();
    }

    // public bool VerifyItemRemoved()
    // {
    //     return countBadgeBy.Displayed;
    // }
    //
    // public void RemoveFromCart(string productName)
    // {
    //     foreach (var product in allItemNameBy)
    //     {
    //         if (product.Text == productName)
    //         {
    //             product.FindElement(removeButtonBy2).Click();
    //             Console.WriteLine($"{productName} removed from cart.");
    //             break;
    //         }
    //     }
    // }
}