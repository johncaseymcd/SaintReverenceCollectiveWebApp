using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class InvoicesProduct
    {
        [ForeignKey(nameof(InvoiceNavigation))]
        public Guid InvoiceID { get; set; }
        [ForeignKey(nameof(ProductNavigation))]
        public int ProductID { get; set; }

        public virtual Invoice InvoiceNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
