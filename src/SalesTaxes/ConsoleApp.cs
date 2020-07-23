using SalesTaxes.SampleData;
using Services.Coupon.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SalesTaxes
{
    internal class ConsoleApp
    {
        private readonly ICouponService couponService;

        public ConsoleApp(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        internal void Run(short inputId, List<ItemSale> saleItems)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Output {inputId}:");

            foreach(var item in saleItems)
            {
                couponService.AddItem(new CouponItem(item.Product,  item.Quantity));
            }

            var coupons = couponService.GetCoupons();
            foreach(var coupon in coupons)
            {
                var impportedStr = coupon.Product.IsImported ? "imported" : "";
                Console.WriteLine($"  •  {coupon.Quantity} {impportedStr} {coupon.Product.Name} at {coupon.TotalAmount}");
            }
            Console.WriteLine($"  •  Sales Taxes: {couponService.GetTotalTaxes()} Total: {couponService.GetTotalAmount()}");

            Console.WriteLine("\n");
        }
    }
}
