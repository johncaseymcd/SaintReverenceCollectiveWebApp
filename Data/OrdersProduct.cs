using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class OrdersProduct
    {
        [ForeignKey(nameof(OrderNavigation))]
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(ProductNavigation))]
        public int ProductId { get; set; }

        public virtual Order OrderNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
