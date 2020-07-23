using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace PointOfSale
{
    public class Coupon
    {
        private readonly List<CouponItem> coupons;
        private readonly ILogger<Coupon> logger;

        public IEnumerable<CouponItem> Coupons => coupons;
        public decimal TotalAmount { get; private set; }
        public decimal TotalTaxes { get; private set; }

        public Coupon(ILogger<Coupon> logger)
        {
            coupons = new List<CouponItem>();
            TotalAmount = 0;
            TotalTaxes = 0;
            this.logger = logger;
        }

        public void AddItem(CouponItem coupon)
        {
            logger.LogDebug($"Adding coupon: {coupon}");

            coupons.Add(coupon);

            TotalAmount += coupon.TotalAmount;
            TotalTaxes += coupon.TotalTaxes;
        }
    }
}
