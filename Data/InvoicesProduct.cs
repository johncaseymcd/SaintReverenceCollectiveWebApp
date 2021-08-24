using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class InvoicesProduct
    {
        public Guid InvoiceId { get; set; }
        public int ProductId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
