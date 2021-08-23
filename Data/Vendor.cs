using System;
using System.Collections.Generic;

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

        public int VendorId { get; set; }
        public string VendorName { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
