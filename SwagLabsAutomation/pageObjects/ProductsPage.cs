using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    
    [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item_name ']")]
    private IList<IWebElement> allItemNameBy;
    
    [FindsBy(How = How.ClassName, Using = "product_sort_container")]
    private IWebElement sortButtonBy;
    
    [FindsBy(How = How.ClassName, Using = "bm-burger-button")]
    private IWebElement menuButtonBy;
    
    [FindsBy(How = How.XPath, Using = "//a[@tabindex='0']")]
    private IList<IWebElement> menuItemsBy;
    
    [FindsBy(How = How.Id, Using = "inventory_sidebar_link")]
    private IWebElement allItemsOption;

    [FindsBy(How = How.Id, Using = "about_sidebar_link")]
    private IWebElement aboutOption;

    [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
    private IWebElement logoutOption;

    [FindsBy(How = How.Id, Using = "reset_sidebar_link")]
    private IWebElement resetAppStateOption;
    
    private By productImageBy = By.XPath("//div[@class='inventory_item_img']");
    
    [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
    private IWebElement shoppingcartBy;
    

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

    public ArrayList BeforeSorting()
    {
        ArrayList itemsBeforeSorting = new ArrayList();
        
        foreach (var product in allItemNameBy)
        {
            itemsBeforeSorting.Add(product.Text);
        }
        return itemsBeforeSorting;
    }

    public ArrayList AfterSorting()
    {
        SelectElement selectElement = new SelectElement(sortButtonBy);
        selectElement.SelectByValue("za");
        
        ArrayList itemsAfterSorting = new ArrayList();
        foreach (var product in allItemNameBy)
        {
            itemsAfterSorting.Add(product.Text);
        }
        return itemsAfterSorting;
    }

    public void ClickToSidebarMenu()
    {
        menuButtonBy.Click();
    }

    public bool AreAllSidebarMenuOptionsDisplayed()
    {
        return allItemsOption.Displayed && aboutOption.Displayed && logoutOption.Displayed && resetAppStateOption.Displayed;
    }

    public bool AreAllProductImagesDisplayed()
    {
        foreach (var product in inventoryItemsBy)
        {
            var productImage = product.FindElement(productImageBy);
            if (!productImage.Displayed)
            {
                return false;
            }
        }
        return true;
    }

    public YourCartPage AddItemToCart()
    {
        AddToCart();
        shoppingcartBy.Click();

        return new YourCartPage(driver);
    }
}