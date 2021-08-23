using System;
using System.Collections.Generic;

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

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal PackageWeightInGrams { get; set; }
        public decimal PackageHeightInCentimeters { get; set; }
        public decimal PackageWidthInCentimeters { get; set; }
        public decimal PackageLengthInCentimeters { get; set; }
        public decimal PackageCostToShip { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
