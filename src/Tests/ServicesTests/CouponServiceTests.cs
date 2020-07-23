using Microsoft.Extensions.DependencyInjection;
using Services.Coupon.Models;
using Services.Interfaces;
using System.Linq;
using Xunit;

namespace ServicesTests
{
    public class CouponServiceTests : ServiceTest
    {
        [Fact]
        public void CalculateItemValueTest()
        {
            var service = serviceProvider.GetRequiredService<ICouponService>();

            var couponItem = new CouponItem(new Product { IsImported = true, IsTaxExempt = false, Name = "product test", UnitPrice = 15.82m }, 1);

            service.AddItem(couponItem);
            var coupons = service.GetCoupons();

            var calcCoupon = coupons.FirstOrDefault();
            Assert.True(coupons.Count() == 1);

            Assert.Equal(18.22m, calcCoupon.TotalAmount);
            Assert.Equal(2.4m, calcCoupon.TotalTaxes);
        }

    }
}
