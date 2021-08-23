using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductBuyCost { get; set; }
        public decimal ProductSellPrice { get; set; }
        public int? ProductInventoryCount { get; set; }
        public int ProductTurnaroundTime { get; set; }
        public decimal ProductWeightInGrams { get; set; }
        public bool ProductIsActive { get; set; }
        public int CategoryId { get; set; }
        public int CollectionId { get; set; }
        public int PackageId { get; set; }
        public int VendorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Collection Collection { get; set; }
        public virtual Package Package { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
