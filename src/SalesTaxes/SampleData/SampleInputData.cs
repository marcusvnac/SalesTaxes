using Services.Coupon.Models;
using System.Collections.Generic;

namespace SalesTaxes.SampleData
{
    public class SampleInputData : IInputData
    {
        private readonly IReadOnlyDictionary<short, List<ItemSale>> SampleData;

        public SampleInputData()
        {
            SampleData = new Dictionary<short, List<ItemSale>>()
            {
               {  1,  new List<ItemSale>()
                    {
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = false, IsTaxExempt = true, Name = "book", UnitPrice = 12.49m } },
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = false, IsTaxExempt = false, Name = "music CD", UnitPrice = 14.99m } },
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = false, IsTaxExempt = true, Name = "chocolate bar", UnitPrice = 0.85m } }
                    }
                },
                { 2, new List<ItemSale>()
                    {
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = true, IsTaxExempt = true, Name = "box of chocolates", UnitPrice = 10.00m } },
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = true, IsTaxExempt = false, Name = "bottle of perfume", UnitPrice = 47.50m } }
                    }
                },
                { 3,  new List<ItemSale>()
                    {
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = true, IsTaxExempt = false, Name = "bottle of perfume", UnitPrice = 27.99m } },
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = false, IsTaxExempt = false, Name = "perfume", UnitPrice = 18.99m } },
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = false, IsTaxExempt = true, Name = "headache pills", UnitPrice = 9.75m } },
                        new ItemSale { Quantity = 1, Product = new Product { IsImported = true, IsTaxExempt = true, Name = "chocolates", UnitPrice = 11.25m } }
                    }
                }
            };
        }

        public IReadOnlyDictionary<short, List<ItemSale>> GetData()
        {
            return SampleData;
        }
    }
}
