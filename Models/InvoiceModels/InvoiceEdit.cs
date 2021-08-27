using System;

namespace SaintReverenceMVC.Models.InvoiceModels
{
    public class InvoiceEdit
    {
        public Guid InvoiceID { get; set; }
        public bool InvoiceIsPaid { get; set; }
        public DateTime PaidDate { get; set; }
    }
}