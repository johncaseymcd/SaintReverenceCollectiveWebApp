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
        public int VendorID { get; set; }
        [Required, MaxLength(100)]
        public string VendorName { get; set; }
        [Required, MaxLength(50)]
        public string VendorWebsite { get; set; }
        [Required, MaxLength(255)]
        public string VendorAddressLine1 { get; set; }
        [MaxLength(255)]
        public string VendorAddressLine2 { get; set; }
        [MaxLength(255)]
        public string VendorAddressLine3 { get; set; }
        [Required, MaxLength(255)]
        public string VendorAddressCity { get; set; }
        [Required, MaxLength(25)]
        public string VendorAddressStateOrProvince { get; set; }
        [Required, MaxLength(25)]
        public string VendorAddressPostalcode { get; set; }
        [Required, MaxLength(100)]
        public string VendorAddressCountry { get; set; }
        [Required, MaxLength(25), Phone]
        public string VendorPhone { get; set; }
        [Required, MaxLength(50), EmailAddress]
        public string VendorEmail { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
