using System.Collections.Generic;

namespace SalesTaxes.SampleData
{
    internal interface IInputData
    {
        IReadOnlyDictionary<short, List<ItemSale>> GetData();
    }
}
