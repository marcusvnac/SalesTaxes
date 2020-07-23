using Services.Coupon.Models;

namespace SalesTaxes.SampleData
{
    /// <summary>
    /// The intent of this class is to simulate how the data can be loeaded into the application
    /// </summary>
    public class ItemSale
    {
        public short Quantity { get; set; }
        public Product Product { get; set; }
    }
}
