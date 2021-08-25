using System;

namespace SaintReverenceMVC.Models.CustomerModels
{
    public class CustomerDetail
    {
        public string CustomerName { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerOrderCount { get; set; }
        public decimal CustomerOrderTotal { get; set; }
    }
}