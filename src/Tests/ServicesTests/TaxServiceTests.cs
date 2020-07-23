using Microsoft.Extensions.DependencyInjection;
using Services.Coupon.Models;
using Services.Interfaces;
using Xunit;

namespace ServicesTests
{
    public class TaxServiceTests : ServiceTest
    {
        [Fact]
        public void CalculateSalesTax_NoTax_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax_Imported_SaleTaxExempt_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(1.25m, salesTax);
        }

        [Fact]
        public void CalculateSalesTax_Imported_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculateSalesTax(couponItem);

            Assert.Equal(1.25m, salesTax);
        }

        [Fact]
        public void CalculatImportTax_SaleTaxExempt_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculatImportTax_Imported_SaleTaxExempt_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = true, Name = "product test", UnitPrice = 15.82m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0.8m, salesTax);
        }

        [Fact]
        public void CalculatImportTax_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0m, salesTax);
        }

        [Fact]
        public void CalculatImportTax_Imported_Test()
        {
            var service = serviceProvider.GetRequiredService<ITaxService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 12.49m }, 1);

            var salesTax = service.CalculatImportTax(couponItem);

            Assert.Equal(0.65m, salesTax);
        }
    }
}
