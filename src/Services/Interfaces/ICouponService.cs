using Services.Coupon.Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICouponService
    {
        void AddItem(CouponItem couponItem);
        IEnumerable<CouponItem> GetCoupons();
        decimal GetTotalAmount();
        decimal GetTotalTaxes();
    }
}
