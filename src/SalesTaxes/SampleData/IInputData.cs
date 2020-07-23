using System.Collections.Generic;

namespace SalesTaxes.SampleData
{
    /// <summary>
    /// This interface provides a way to input data to the program to simulate usage
    /// </summary>
    internal interface IInputData
    {
        IReadOnlyDictionary<short, List<ItemSale>> GetData();
    }
}
