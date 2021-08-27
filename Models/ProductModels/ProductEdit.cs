using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.ProductModels
{
    public class ProductEdit
    {
        public int ProductID { get; set; }
        [MaxLength(100)]
        public string ProductName { get; set; }
        [MaxLength(1000)]
        public string ProductDescription { get; set; }
        public decimal ProductSellPrice { get; set; }
        public int ProductInventoryCount { get; set; }
        public bool ProductIsActive { get; set; }
    }
}