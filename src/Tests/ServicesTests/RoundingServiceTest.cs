using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Xunit;

namespace ServicesTests
{
    public class RoundingServiceTest : ServiceTest
    {
        [Fact]
        public void RoundTest1()
        {
            var service = serviceProvider.GetRequiredService<IRoundingService>();

            var result = service.Round(15.82m);

            Assert.Equal(15.85m, result);
        }

        [Fact]
        public void RoundTest2()
        {
            var service = serviceProvider.GetRequiredService<IRoundingService>();

            var result = service.Round(0.5625m);

            Assert.Equal(0.6m, result);
        }

        [Fact]
        public void RoundTest3()
        {
            var service = serviceProvider.GetRequiredService<IRoundingService>();

            var result = service.Round(4.75m);

            Assert.Equal(4.75m, result);
        }

        [Fact]
        public void RoundTest4()
        {
            var service = serviceProvider.GetRequiredService<IRoundingService>();

            var result = service.Round(2.375m);

            Assert.Equal(2.40m, result);
        }
    }
}
