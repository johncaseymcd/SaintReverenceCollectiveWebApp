using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Order
    {
        public Order()
        {
            OrdersProducts = new HashSet<OrdersProduct>();
        }
        [Key]
        public Guid OrderID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        [ForeignKey(nameof(OrderStatusNavigation))]
        public int OrderStatus { get; set; }
        [ForeignKey(nameof(CustomerNavigation))]
        public Guid CustomerID { get; set; }
        [ForeignKey(nameof(PackageNavigation))]
        public int PackageID { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Status OrderStatusNavigation { get; set; }
        public virtual Package PackageNavigation { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
    }
}
