using Services.Interfaces;

namespace ServicesTests.SampleData
{
    public class TestTaxeIndexs : ITaxIndex
    {
        public decimal SalesTax() => 0.10m;
        public decimal ImportTax() => 0.05m;
    }
}
