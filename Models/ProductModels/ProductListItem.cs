namespace SaintReverenceMVC.Models.ProductModels
{
    public class ProductListItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductSellPrice { get; set; }
        public int ProductInventoryCount { get; set; }   
        public int ProductTurnaroundTime { get; set; }
        public int CategoryID { get; set; }
        public int CollectionID { get; set; }
    }
}