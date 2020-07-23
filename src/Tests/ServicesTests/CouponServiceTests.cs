using Microsoft.Extensions.DependencyInjection;
using Services.Coupon.Models;
using Services.Interfaces;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace ServicesTests
{
    public class CouponServiceTests : ServiceTest
    {
        [Fact]
        public void CalculateItemValueTest()
        {
            var service = ServiceProvider.GetRequiredService<ICouponService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 15.82m }, 1);

            service.AddItem(couponItem);
            var coupons = service.GetCoupons();

            var calcCoupon = coupons.FirstOrDefault();
            Assert.True(coupons.Count() == 1);

            Assert.Equal(18.22m, calcCoupon.TotalAmount);
            Assert.Equal(2.4m, calcCoupon.TotalTaxes);
        }

        [Fact]
        public void CalculateItemValueOutput1Test()
        {
            var service = ServiceProvider.GetRequiredService<ICouponService>();

            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = true, Name = "book", UnitPrice = 12.49m }, 1));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "music CD", UnitPrice = 14.99m }, 1));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = true, Name = "chocolate bar", UnitPrice = 0.85m }, 1));

            var coupons = service.GetCoupons();

            Assert.True(coupons.Count() == 3);
            Assert.Equal(12.49m, coupons.ElementAt(0).TotalAmount);
            Assert.Equal(16.49m, coupons.ElementAt(1).TotalAmount);
            Assert.Equal(0.85m, coupons.ElementAt(2).TotalAmount);
            Assert.Equal(29.83m, service.GetTotalAmount());
            Assert.Equal(1.50m, service.GetTotalTaxes());
        }

        [Fact]
        public void CalculateItemValueOutput2Test()
        {
            var service = ServiceProvider.GetRequiredService<ICouponService>();

            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = true, Name = "box of chocolates", UnitPrice = 10.00m }, 1));
            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "bottle of perfume", UnitPrice = 47.50m }, 1));

            var coupons = service.GetCoupons();

            Assert.True(coupons.Count() == 2);
            Assert.Equal(10.50m, coupons.ElementAt(0).TotalAmount);
            Assert.Equal(54.65m, coupons.ElementAt(1).TotalAmount);
            Assert.Equal(65.15m, service.GetTotalAmount());
            Assert.Equal(7.65m, service.GetTotalTaxes());
        }

        [Fact]
        public void CalculateItemValueOutput3Test()
        {
            var service = ServiceProvider.GetRequiredService<ICouponService>();

            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "bottle of perfume", UnitPrice = 27.99m }, 1));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "perfume", UnitPrice = 18.99m }, 1));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = true, Name = "headache pills", UnitPrice = 9.75m }, 1));
            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = true, Name = "chocolates", UnitPrice = 11.25m }, 1));

            var coupons = service.GetCoupons();

            Assert.True(coupons.Count() == 4);
            Assert.Equal(32.19m, coupons.ElementAt(0).TotalAmount);
            Assert.Equal(20.89m, coupons.ElementAt(1).TotalAmount);
            Assert.Equal(9.75m, coupons.ElementAt(2).TotalAmount);
            Assert.Equal(11.85m, coupons.ElementAt(3).TotalAmount);
            Assert.Equal(74.68m, service.GetTotalAmount());
            Assert.Equal(6.70m, service.GetTotalTaxes());
        }

        [Fact]
        public void CalculateItemValueQtdMoreThanOneAllImportNoExemptTest()
        {
            var service = ServiceProvider.GetRequiredService<ICouponService>();

            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "bottle of perfume", UnitPrice = 15.89m }, 2));
            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "perfume", UnitPrice = 5.98m }, 4));
            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "shorts", UnitPrice = 10.79m }, 3));
            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "toy", UnitPrice = 6.53m }, 5));
            service.AddItem(new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "keychain", UnitPrice = 1.25m }, 10));

            var coupons = service.GetCoupons();

            Assert.True(coupons.Count() == 5);
            Assert.Equal(36.58m, coupons.ElementAt(0).TotalAmount);
            Assert.Equal(27.52m, coupons.ElementAt(1).TotalAmount);
            Assert.Equal(37.27m, coupons.ElementAt(2).TotalAmount);
            Assert.Equal(37.60m, coupons.ElementAt(3).TotalAmount);
            Assert.Equal(14.40m, coupons.ElementAt(4).TotalAmount);
            Assert.Equal(153.37m, service.GetTotalAmount());
            Assert.Equal(20.15m, service.GetTotalTaxes());
        }

        [Fact]
        public void CalculateItemValuetQtdMoreThanOneNoExemptTest()
        {
            var service = ServiceProvider.GetRequiredService<ICouponService>();

            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "bottle of perfume", UnitPrice = 15.89m }, 2));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "perfume", UnitPrice = 5.98m }, 4));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "shorts", UnitPrice = 10.79m }, 3));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "toy", UnitPrice = 6.53m }, 5));
            service.AddItem(new CouponItem(new Product { IsImported = false, IsTaxExempt = false, Name = "keychain", UnitPrice = 1.25m }, 10));

            var coupons = service.GetCoupons();

            Assert.True(coupons.Count() == 5);
            Assert.Equal(34.98m, coupons.ElementAt(0).TotalAmount);
            Assert.Equal(26.32m, coupons.ElementAt(1).TotalAmount);
            Assert.Equal(35.62m, coupons.ElementAt(2).TotalAmount);
            Assert.Equal(35.95m, coupons.ElementAt(3).TotalAmount);
            Assert.Equal(13.75m, coupons.ElementAt(4).TotalAmount);
            Assert.Equal(146.62m, service.GetTotalAmount());
            Assert.Equal(13.40m, service.GetTotalTaxes());
        }
    }
}
