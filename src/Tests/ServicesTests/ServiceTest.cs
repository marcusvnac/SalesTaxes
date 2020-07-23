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
        protected static ServiceProvider serviceProvider;

        public ServiceTest()
        {
            // Setting up DI container
            serviceProvider = new ServiceCollection()
                  .AddLogging()
                  .AddTransient<IRoundingService, RoundingService>()
                  .AddTransient<ITaxIndex, TestTaxes>()
                  .AddTransient<ITaxService, TaxService>()
                  .AddTransient<ICouponService, CouponService>()
                  .BuildServiceProvider(true);
        }

    }
}
