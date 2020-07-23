using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;

namespace Services.Rounding
{
    public class RoundingService : IRoundingService
    {
        private readonly ILogger<RoundingService> logger;

        public RoundingService(ILogger<RoundingService> logger)
        {
            this.logger = logger;
        }
        
        public decimal Round(decimal value)
        {
            //decimal result = Decimal.Round(value*20, MidpointRounding.AwayFromZero) / 20;
            //decimal result = Decimal.Round(value, 2);
            decimal result = Decimal.Ceiling(value / 0.05m) * 0.05m;

            logger.LogDebug($"Rouding original value '{value}' to '{result}'");

            return result;

        }
    }
}
