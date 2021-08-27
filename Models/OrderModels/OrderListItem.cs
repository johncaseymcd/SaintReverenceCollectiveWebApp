using System;

namespace SaintReverenceMVC.Models.OrderModels
{
    public class OrderListItem
    {
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public decimal OrderTotal { get; set; }
        public Guid CustomerID { get; set; }
    }
}