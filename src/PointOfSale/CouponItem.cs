using Models;
using Services.Interfaces;
using System.Text.Json;

namespace PointOfSale
{
    public class CouponItem
    {
        // Storing pre-calculated taxes to caching purposes
        private decimal totalTaxes = decimal.MinValue;
        private readonly IRoundingService roundingService;

        public Product Product { get; internal set; }
        public int Quantity { get; internal set; }
        public decimal TotalAmount => CalulateTotalAmount();
        public decimal TotalTaxes => CalculateTotalTaxes();

        public CouponItem(IRoundingService roundingService,
            Product product, int quantity)
        {
            this.roundingService = roundingService;

            Product = product;
            Quantity = quantity;
        }

        private decimal CalulateTotalAmount()
        {
            return roundingService.Round((Product.UnitPrice * Quantity) + CalculateTotalTaxes());
        }

        private decimal CalculateTotalTaxes()
        {
            if (totalTaxes == decimal.MinValue)
            {
                totalTaxes = Product.UnitPrice * Quantity;
                if (!Product.IsTaxExempt)
                {
                    totalTaxes = roundingService.Round(totalTaxes * Taxes.Sales);

                    if (!Product.IsImported)
                    {
                        totalTaxes = roundingService.Round(totalTaxes * Taxes.Import);
                    }
                }                
            }
            return totalTaxes;
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
