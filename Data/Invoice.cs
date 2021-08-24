using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoicesProducts = new HashSet<InvoicesProduct>();
        }

        public Guid InvoiceId { get; set; }
        public decimal CostOfProducts { get; set; }
        public decimal TaxPaid { get; set; }
        public decimal ShippingPaid { get; set; }
        public decimal AdditionalFees { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool InvoiceIsPaid { get; set; }
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<InvoicesProduct> InvoicesProducts { get; set; }
    }
}
