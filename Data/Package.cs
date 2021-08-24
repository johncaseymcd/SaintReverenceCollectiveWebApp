using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Package
    {
        public Package()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int PackageId { get; set; }
        [Required, MaxLength(100)]
        public string PackageName { get; set; }
        [Required]
        public decimal PackageWeightInGrams { get; set; }
        [Required]
        public decimal PackageHeightInCentimeters { get; set; }
        [Required]
        public decimal PackageWidthInCentimeters { get; set; }
        [Required]
        public decimal PackageLengthInCentimeters { get; set; }
        [Required]
        public decimal PackageCostToShip { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
