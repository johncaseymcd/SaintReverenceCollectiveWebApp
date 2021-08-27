namespace SaintReverenceMVC.Models.ProductModels
{
    public class ProductListItem
    {
        public string ProductName { get; set; }
        public decimal ProductSellPrice { get; set; }
        public int ProductInventoryCount { get; set; }   
        public int ProductTurnaroundTime { get; set; }
        public int CollectionID { get; set; }
    }
}