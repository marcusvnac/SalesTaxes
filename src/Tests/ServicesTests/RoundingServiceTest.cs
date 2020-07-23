using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Xunit;

namespace ServicesTests
{
    public class RoundingServiceTest : ServiceTest
    {
        [Theory]
        [InlineData(2.36, 2.40)]
        [InlineData(4.75, 4.75)]
        [InlineData(2.31, 2.35)]
        [InlineData(0.5625, 0.6)]
        [InlineData(2.375, 2.40)]
        [InlineData(15.82, 15.85)]
        public void RoundTest(decimal toRound, decimal expectedRounded)
        {
            var service = ServiceProvider.GetRequiredService<IRoundingService>();

            var result = service.Round(toRound);

            Assert.Equal(expectedRounded, result);
        }
    }
}
