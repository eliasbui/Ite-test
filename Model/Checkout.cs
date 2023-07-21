namespace Ite_Test.Model
{
  public class Checkout
  {
    private List<Product> products;
    // initialize the scannedItems dictionary
    private Dictionary<string, int> scannedItems;
    //dictionary to store the scanned items and their quantities (SKU, quantity) return the total price of all scanned items
    private List<PricingRule> pricingRules;

    public Checkout(List<Product> products, List<PricingRule> pricingRules)
    {
      this.products = products;
      this.pricingRules = pricingRules;
      scannedItems = new Dictionary<string, int>();
    }

    public void Scan(string SKU)
    {
      // check if the item has been scanned
      if (scannedItems.ContainsKey(SKU))
      {
        // if the item has been scanned, increase the quantity by 1
        scannedItems[SKU]++;
      }
      else
      {
        // if the item has not been scanned, add it to the dictionary with quantity 1
        scannedItems[SKU] = 1;
      }
    }
    public decimal Total()
    {
      //initialize the totalAmount variable with 0
      decimal totalAmount = 0;
      //apply pricing rules
      //loop through the scanned items
      var scannedSKUs = scannedItems.Keys.ToList();
      foreach (var sku in scannedSKUs)
      {
        var product = products.FirstOrDefault(p => p.SKU == sku);
        if (product != null)
        {
          int quantity = scannedItems[sku];
          totalAmount += CalculatePriceWithDiscount(product, quantity);
        }
      }
      return totalAmount;
    }
    private decimal CalculatePriceWithDiscount(Product product, int quantity)
    {
      // Apply the 3 for 2 deal on Apple TVs
      if (product.SKU == "atv" && quantity >= 3)
      {
        //Number of products on sale
        //result is 1 if quantity is 3, 2 if quantity is 6, etc. and 0 if quantity is 2
        int discountedSets = quantity / 3;
        //Number of products not on sale
        //result is 0 if quantity is 3, 1 if quantity is 4, etc. and 2 if quantity is 5
        int regularSets = quantity % 3;
        //Calculate the total price of all products on sale and not on sale and return it
        //syntax: discountedSets * 2 * product.Price + regularSets * product.Price
        return discountedSets * 2 * product.Price + regularSets * product.Price;
      }
      // Apply the bulk discount for Super iPads
      else if (product.SKU == "ipd" && quantity > 4)
      {
        //m is for decimal
        return quantity * 499.99m;
      }
      // Bundle free VGA adapter with MacBook Pro
      else if (product.SKU == "mbp")
      {
        //get the number of VGA adapters in the scanned itemsGet the number of products whose SKUs are vga (if none exist, assigned to 0)
        //? : is the 3-person operator
        //if scannedItems contains the key "vga", assign the value of scannedItems["vga"] to vgaCount
        //if scannedItems does not contain the key "vga", assign 0 to vgaCount
        int vgaCount = scannedItems.ContainsKey("vga") ? scannedItems["vga"] : 0;
        //Returns the number of products with the smallest discounted price
        int applicableMac = Math.Min(quantity, vgaCount + 1);
        //Returns the number of products with the largest discounted price
        int remainingVGA = Math.Max(0, vgaCount - quantity + 1);
        // ==================================================================
        //if you don't know what Math.Min or Math.Max
        //Math.Max or Math.Min returns the largest or smallest of two numbers
        // ==================================================================
        //update the number of VGA adapters in the scanned items
        scannedItems["vga"] = remainingVGA;
        //return the total price of the products
        return applicableMac * product.Price;
      }
      else
      {
        return quantity * product.Price; //no discount
      }
    }
  }
}
