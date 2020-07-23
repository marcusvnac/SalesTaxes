namespace Services.Coupon.Models
{
    public class Product
    {
        public bool IsImported { get; set; }
        public bool IsTaxExempt { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
