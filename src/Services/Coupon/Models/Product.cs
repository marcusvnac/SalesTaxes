namespace Services.Coupon.Models
{
    /// <summary>
    /// Represents a product that can be bought by a client
    /// </summary>
    public class Product
    {
        public bool IsImported { get; set; }
        public bool IsTaxExempt { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
