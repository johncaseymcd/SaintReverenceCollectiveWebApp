using System;

namespace SaintReverenceMVC.Models.OrderModels
{
    public class OrderDetail
    {
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal OrderTotal { get; set; }
        public int OrderStatus { get; set; }
        public Guid CustomerID { get; set; }
        public int PackageID { get; set; }
    }
}