using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.ProductModels
{
    public class ProductCreate
    {
        [Required, MaxLength(100)]
        public string ProductName { get; set; }
        [MaxLength(1000)]
        public string ProductDescription { get; set; }
        [Required]
        public decimal ProductBuyCost { get; set; }
        [Required]
        public decimal ProductSellPrice { get; set; }
        public int ProductInventoryCount { get; set; }
        [Required]
        public int ProductTurnaroundTime { get; set; }
        [Required]
        public decimal ProductWeightInGrams { get; set; }
        [Required]
        public bool ProductIsActive { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int CollectionID { get; set; }
        [Required]
        public int PackageID { get; set; }
        [Required]
        public int VendorID { get; set; }
    }
}