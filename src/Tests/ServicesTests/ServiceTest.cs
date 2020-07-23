using Microsoft.Extensions.DependencyInjection;
using Services.Coupon;
using Services.Interfaces;
using Services.Rounding;
using Services.Tax;
using ServicesTests.SampleData;

namespace ServicesTests
{
    public abstract class ServiceTest
    {
        protected ServiceProvider ServiceProvider { get; private set; }

        public ServiceTest()
        {
            // Setting up DI container
            ServiceProvider = new ServiceCollection()
                  .AddLogging()
                  .AddTransient<IRoundingService, RoundingService>()
                  .AddTransient<ITaxIndex, TestTaxeIndexs>()
                  .AddTransient<ITaxService, TaxService>()
                  .AddTransient<ICouponService, CouponService>()
                  .BuildServiceProvider(true);
        }
    }
}
