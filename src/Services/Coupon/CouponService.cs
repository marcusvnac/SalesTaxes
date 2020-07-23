using Microsoft.Extensions.Logging;
using Services.Coupon.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Coupon
{
    public class CouponService : ICouponService
    {
        private readonly List<CouponItem> coupons;
        private readonly ITaxService taxService;
        private readonly ILogger<CouponService> logger;
        private decimal totalAmount;
        private decimal totalTaxes;

        public CouponService(ITaxService taxService,
            ILogger<CouponService> logger)
        {
            coupons = new List<CouponItem>();
            totalAmount = 0;
            totalTaxes = 0;
            this.taxService = taxService;
            this.logger = logger;
        }

        public void AddItem(CouponItem couponItem)
        {
            if (couponItem == null)
                throw new ArgumentNullException(nameof(couponItem));

            var saleTax = taxService.CalculateSalesTax(couponItem);
            var importTax = taxService.CalculatImportTax(couponItem);
            couponItem.TotalTaxes = saleTax + importTax;

            logger.LogDebug($"Total Tax Calculation for Product '{couponItem.Product.Name}' | Quantity {couponItem.Quantity} = {couponItem.TotalTaxes}. Total Amount = {couponItem.TotalAmount}");
            logger.LogDebug($"Adding coupon: {couponItem}");

            coupons.Add(couponItem);

            totalAmount += couponItem.TotalAmount;
            totalTaxes += couponItem.TotalTaxes;
        }

        public IEnumerable<CouponItem> GetCoupons()
        {
            logger.LogDebug($"{coupons.Count} coupons created");

            return coupons;
        }

        public decimal GetTotalAmount() => totalAmount;

        public decimal GetTotalTaxes() => totalTaxes;
    }
}
