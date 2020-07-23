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

            CalculateTaxes(couponItem);

            logger.LogDebug($"Adding coupon: {couponItem}");

            coupons.Add(couponItem);

            CalculateTotals(couponItem);
        }

        public IEnumerable<CouponItem> GetCoupons()
        {
            logger.LogDebug($"{coupons.Count} coupons created");

            return coupons;
        }

        private void CalculateTaxes(CouponItem couponItem)
        {
            var saleTax = taxService.CalculateSalesTax(couponItem);
            var importTax = taxService.CalculatImportTax(couponItem);
            couponItem.TotalTaxes = saleTax + importTax;
        }

        private void CalculateTotals(CouponItem couponItem)
        {
            totalAmount += couponItem.TotalAmount;
            totalTaxes += couponItem.TotalTaxes;
        }

        public decimal GetTotalAmount() => totalAmount;

        public decimal GetTotalTaxes() => totalTaxes;
    }
}
