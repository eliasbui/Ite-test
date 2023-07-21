namespace IteTestExample
{
  using Ite_Test.Model;
  class Program
  {
    static void Main(string[] args)
    {
      // Create products and pricing rules
      var products = new List<Product>
      {
        new Product { SKU = "ipd", Name = "Super iPad", Price = 549.99m },
        new Product { SKU = "mbp", Name = "MacBook Pro", Price = 1399.99m },
        new Product { SKU = "atv", Name = "Apple TV", Price = 109.50m },
        new Product { SKU = "vga", Name = "VGA adapter", Price = 30.00m }
      };
      var pricingRules = new List<PricingRule>
      {
        // Apply the 3 for 2 deal on Apple TVs
       new PricingRule { SKU = "atv", Type = PricingRuleType.ThreeForTwoDeal },
       // Apply the discount on Super iPads when 4 or more are purchased
       new PricingRule { SKU = "ipd", Type = PricingRuleType.BulkDiscount, QuantityForDiscount = 5, DiscountedPrice = 499.99m },
       // Bundle free VGA adapter with MacBook Pro
       new PricingRule { SKU = "mbp", Type = PricingRuleType.Bundle } // Sản phẩm mbp được tặng kèm sản phẩm vga
      };
      //show products
      Console.WriteLine("Products in store:");
      foreach (var product in products)
      {
        Console.WriteLine($"{product.SKU} - {product.Name} - {product.Price:C}");
      }
      Console.WriteLine();
      // Create checkout object and scan products until the user enters "done"
      Checkout co = new Checkout(products, pricingRules);
      // List of entered SKUs, use to display at the end program
      List<string> enteredSKUs = new List<string>();
      // Loop until the user enters "done"
      //using while loop because know how many times the user will enter a SKU before entering "done"
      while (true)
      {
        Console.WriteLine("Enter the SKU of the product (or 'done' to finish checkout):");
        //use trim to remove any leading or trailing whitespace
        string? sku = Console.ReadLine()?.Trim();
        //if the user enters "done", break out of the loop and continue with the rest of the program
        if (sku?.ToLower().Trim() == "done")
        {
          break;
        }
        var product = products.Find(p =>
        {
          return p.SKU == sku;
        }); // find product by SKU using LINQ and lambda expression
        if (product == null)
        {
          Console.WriteLine("Invalid product SKU. Please try again.");
          continue;
        }
        //if the product is found, scan it and add it to the list of entered SKUs
        if (sku != null)
        {
          //scan the product
          co.Scan(sku);
          //add the SKU to the list of entered SKUs
          enteredSKUs.Add(sku);
        }
      }
      decimal total = co.Total();
      Console.WriteLine("SKUs Scanned :");
      //display the list of entered SKUs
      Console.WriteLine(string.Join(", ", enteredSKUs));
      Console.WriteLine($"Total amount: {total:C}");
    }
  }
}
