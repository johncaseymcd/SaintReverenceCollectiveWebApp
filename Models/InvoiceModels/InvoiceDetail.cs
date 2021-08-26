using System; 

namespace SaintReverenceMVC.Models.InvoiceModels
{
    public class InvoiceDetail
    {
        public decimal TotalCost { get; set; }
        public decimal TaxPaid { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool InvoiceIsPaid { get; set; }
        public DateTime PaidDate { get; set; }
        public int VendorID { get; set; }
    }
}