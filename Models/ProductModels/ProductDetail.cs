namespace SaintReverenceMVC.Models.ProductModels
{
    public class ProductDetail
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductBuyCost { get; set; }
        public decimal ProductSellPrice { get; set; }
        public int ProductInventoryCount { get; set; }
        public int ProductMaxInventoryCount { get; set; }
        public decimal ProductWeightInGrams { get; set; }
        public bool ProductIsActive { get; set; }
        public int CategoryID { get; set; }
        public int CollectionID { get; set; }
        public int VendorID { get; set; }
    }
}