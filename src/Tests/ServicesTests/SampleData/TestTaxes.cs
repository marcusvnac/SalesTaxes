using Services.Interfaces;

namespace ServicesTests.SampleData
{
    public class TestTaxes : ITaxIndex
    {
        public decimal SalesTax() => 0.10m;
        public decimal ImportTax() => 0.05m;
    }
}
