namespace SaintReverenceMVC.Models.ProductModels
{
    public class ProductEdit
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductSellPrice { get; set; }
        public int ProductInventoryCount { get; set; }
        public bool ProductIsActive { get; set; }
    }
}