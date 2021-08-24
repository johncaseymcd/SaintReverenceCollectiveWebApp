using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Vendor
    {
        public Vendor()
        {
            Invoices = new HashSet<Invoice>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int VendorId { get; set; }
        [Required, MaxLength(100)]
        public string VendorName { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
