using Services.Coupon.Models;

namespace Services.Interfaces
{
    public interface ITaxService
    {
        decimal CalculateSalesTax(CouponItem couponItem);
        decimal CalculatImportTax(CouponItem couponItem);
    }
}
