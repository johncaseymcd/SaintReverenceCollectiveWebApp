using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int OrderStatus { get; set; }
        public Guid CustomerId { get; set; }
        public int PackageId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Status OrderStatusNavigation { get; set; }
        public virtual Package Package { get; set; }
    }
}
