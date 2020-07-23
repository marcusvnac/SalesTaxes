using Services.Coupon.Models;

namespace Services.Interfaces
{
    public interface ITaxService
    {
        public decimal CalculateSalesTax(CouponItem couponItem);
        public decimal CalculatImportTax(CouponItem couponItem);
    }
}
