using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoicesProducts = new HashSet<InvoicesProduct>();
        }
        [Key]

        public Guid InvoiceID { get; set; }
        [Required]
        public decimal CostOfProducts { get; set; }
        [Required]
        public decimal TaxPaid { get; set; }
        [Required]
        public decimal ShippingPaid { get; set; }
        [Required]
        public decimal AdditionalFees { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public bool InvoiceIsPaid { get; set; }
        [ForeignKey(nameof(VendorNavigation))]
        public int VendorID { get; set; }
        public DateTime? PaidDate { get; set; }

        public virtual Vendor VendorNavigation { get; set; }
        public virtual ICollection<InvoicesProduct> InvoicesProducts { get; set; }
    }
}
