using Services.Coupon.Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICouponService
    {
        public void AddItem(CouponItem couponItem);
        public IEnumerable<CouponItem> GetCoupons();
        public decimal GetTotalAmount();
        public decimal GetTotalTaxes();
    }
}
