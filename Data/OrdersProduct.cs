using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class OrdersProduct
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
