using System;
using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.InvoiceModels
{
    public class InvoiceCreate
    {
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
        public DateTime PaidDate { get; set; }
        [Required]
        public int VendorID { get; set; }
    }
}