﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SalesTaxes.SampleData;
using Services.Coupon;
using Services.Interfaces;
using Services.Rounding;
using Services.Tax;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SalesTaxes
{
    public class Program
    {
        private static ServiceProvider serviceProvider;

        static void Main()
        {
            RegisterServices();

            var inputData = serviceProvider.GetService<IInputData>();
            var data = inputData.GetData();

            foreach (KeyValuePair<short, List<ItemSale>> entry in data)
            {
                // For every iteraction a new instance of ConsoleApp and CouponService are created
                IServiceScope scope = serviceProvider.CreateScope();

                scope.ServiceProvider.GetRequiredService<ConsoleApp>().Run(entry.Key, entry.Value);

                scope.Dispose();
            }

            DisposeServices();
        }

        private static void RegisterServices()
        {
            // Setting up DI container
            var serviceCollection = new ServiceCollection()
                  .AddScoped<ConsoleApp>()
                  .AddSingleton<IInputData, SampleInputData>()
                  .AddSingleton<IRoundingService, RoundingService>()
                  .AddSingleton<ITaxService, TaxService>()
                  .AddSingleton<ITaxIndex, SampleTaxes>()
                  .AddScoped<ICouponService, CouponService>();

            if (Debugger.IsAttached)
            {
                serviceCollection.AddLogging(cnf => cnf.AddConsole().SetMinimumLevel(LogLevel.Debug));
            }
            else
            {
                serviceCollection.AddLogging(cnf => cnf.AddConsole());
            }

            serviceProvider = serviceCollection.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
