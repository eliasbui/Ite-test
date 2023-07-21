namespace Ite_Test.Model
{
  // Initialize the PricingRuleType enum with values ThreeForTwoDeal, BulkDiscount, Bundle
  public enum PricingRuleType
  // The values of the PricingRuleType enum will be used to determine the price category of the product
  {
    ThreeForTwoDeal, // Buy 3 get 2 use for Apple TVs
    BulkDiscount, // Discount for buying in bulk use for Super iPads
    Bundle // Combo use for MacBook Pro and VGA adapter
  }
  public class PricingRule
  {
    // initialize the PricingRule object with SKU, Type, QuantityForDiscount, DiscountedPrice attributes
    public string SKU { get; set; } = string.Empty;
    public PricingRuleType Type { get; set; }
    public int QuantityForDiscount { get; set; }
    public decimal DiscountedPrice { get; set; }
  }
}
