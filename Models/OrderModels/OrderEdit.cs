using System;

namespace SaintReverenceMVC.Models.OrderModels
{
    public class OrderEdit
    {
        public Guid OrderID { get; set; }
        public int OrderStatus { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}