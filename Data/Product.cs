using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Product
    {
        public Product()
        {
            InvoicesProducts = new HashSet<InvoicesProduct>();
            OrdersProducts = new HashSet<OrdersProduct>();
        }

        [Key]
        public int ProductId { get; set; }
        [Required, MaxLength(100)]
        public string ProductName { get; set; }
        [MaxLength(1000)]
        public string ProductDescription { get; set; }
        [Required]
        public decimal ProductBuyCost { get; set; }
        [Required]
        public decimal ProductSellPrice { get; set; }
        public int? ProductInventoryCount { get; set; }
        [Required]
        public int ProductTurnaroundTime { get; set; }
        [Required]
        public decimal ProductWeightInGrams { get; set; }
        [Required]
        public bool ProductIsActive { get; set; }
        [ForeignKey(nameof(CategoryNavigation))]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CollectionNavigation))]
        public int CollectionId { get; set; }
        [ForeignKey(nameof(PackageNavigation))]
        public int PackageId { get; set; }
        [ForeignKey(nameof(VendorNavigation))]
        public int VendorId { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual Collection CollectionNavigation { get; set; }
        public virtual Package PackageNavigation { get; set; }
        public virtual Vendor VendorNavigation { get; set; }
        public virtual ICollection<InvoicesProduct> InvoicesProducts { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
    }
}
