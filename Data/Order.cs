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
        public Guid OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Required]
        public int OrderStatus { get; set; }
        [ForeignKey(nameof(CustomerNavigation))]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(PackageNavigation))]
        public int PackageId { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Status OrderStatusNavigation { get; set; }
        public virtual Package PackageNavigation { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
    }
}
