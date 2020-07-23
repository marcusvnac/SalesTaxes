using Services.Interfaces;

namespace SalesTaxes.SampleData
{
    /// <summary>
    /// Taxes to be applied on sales.
    /// In a real-world application, the values could be loaded from a data storage like a database or in a simpler solution, from a configuration file.
    /// </summary>
    public class SampleTaxes : ITaxData
    {
        public decimal SalesTax() => 0.10m;
        public decimal ImportTax() => 0.05m;
    }
}
