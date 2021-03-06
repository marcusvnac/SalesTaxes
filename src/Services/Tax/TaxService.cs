﻿using Microsoft.Extensions.Logging;
using Services.Coupon.Models;
using Services.Interfaces;
using System;

namespace Services.Tax
{
    public class TaxService : ITaxService
    {
        private readonly ITaxIndex taxData;
        private readonly IRoundingService roundingService;
        private readonly ILogger<TaxService> logger;

        public TaxService(ITaxIndex taxData,
            IRoundingService roundingService,
            ILogger<TaxService> logger)
        {
            this.taxData = taxData;
            this.roundingService = roundingService;
            this.logger = logger;
        }

        public decimal CalculateSalesTax(CouponItem couponItem)
        {
            if (couponItem == null)
                throw new ArgumentNullException(nameof(couponItem));

            decimal saleTaxes = 0m;
            if (!couponItem.Product.IsTaxExempt)
            {
                saleTaxes = couponItem.Product.UnitPrice * couponItem.Quantity;
                saleTaxes = roundingService.Round(saleTaxes * taxData.SalesTax());

                logger.LogDebug($"Sales Tax for Product '{couponItem.Product.Name}' | Unit Price '{couponItem.Product.UnitPrice}' | Quantity {couponItem.Quantity} = {saleTaxes}");
            }

            return saleTaxes;
        }

        public decimal CalculatImportTax(CouponItem couponItem)
        {
            if (couponItem == null)
                throw new ArgumentNullException(nameof(couponItem));

            decimal importTaxes = 0;
            if (couponItem.Product.IsImported)
            {
                importTaxes = couponItem.Product.UnitPrice * couponItem.Quantity;
                importTaxes = roundingService.Round(importTaxes * taxData.ImportTax());

                logger.LogDebug($"Import Tax for Product '{couponItem.Product.Name}' | Unit Price '{couponItem.Product.UnitPrice}' | Quantity {couponItem.Quantity} = {importTaxes}");
            }
            return importTaxes;
        }
    }
}
