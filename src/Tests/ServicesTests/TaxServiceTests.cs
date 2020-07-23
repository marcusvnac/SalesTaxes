using Microsoft.Extensions.DependencyInjection;
using Services.Coupon.Models;
using Services.Interfaces;
using Xunit;

namespace ServicesTests
{
    public class TaxServiceTests : ServiceTest
    {
        #region SalesTaxesTests
        [Fact]
        public void CalculateSalesTaxNoTaxTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculateSalesTaxImportedSaleTaxExemptTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculateSalesTaxTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(1.25m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax2UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 15.89m }, 2);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(3.20m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax3UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 10.79m }, 3);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(3.25m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax4UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 5.98m }, 4);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(2.40m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax5UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 6.53m }, 5);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(3.30m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax10UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 1.25m }, 10);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(1.25m, salesTax);
        }

        #endregion
        #region ImportTaxesTest
        [Fact]
        public void CalculateSalesTaxImportedTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(1.25m, salesTax);
        }

        [Fact]
        public void CalculatImportTaxSaleTaxExemptTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculatImportTaxImportedSaleTaxExemptTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0.8m, salesTax);
        }

        [Fact]
        public void CalculatImportTaxTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculatImportTaxImportedTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0.65m, salesTax);
        }

        [Fact]
        public void CalculateImportTax2UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 15.89m }, 2);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(1.60m, salesTax);
        }

        [Fact]
        public void CalculateImportTax3UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 10.79m }, 3);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(1.65m, salesTax);
        }

        [Fact]
        public void CalculateImportTax4UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 5.98m }, 4);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(1.20m, salesTax);
        }

        [Fact]
        public void CalculateImportTax5UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 6.53m }, 5);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(1.65m, salesTax);
        }

        [Fact]
        public void CalculateImportTax10UnitsTest()
        {
            var service = ServiceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 1.25m }, 10);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0.65m, salesTax);
        }
        #endregion
    }
}
