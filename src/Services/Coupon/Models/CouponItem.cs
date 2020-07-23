using System.Text.Json;

namespace Services.Coupon.Models
{
    public class CouponItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalTaxes { get; internal set; }
        public decimal TotalAmount => CalulateTotalAmount();

        public CouponItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        private decimal CalulateTotalAmount()
        {
            return (Product.UnitPrice * Quantity) + TotalTaxes;
        }

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
}
