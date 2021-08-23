using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public Guid CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddressLine1 { get; set; }
        public string CustomerAddressLine2 { get; set; }
        public string CustomerAddressLine3 { get; set; }
        public string CustomerAddressCity { get; set; }
        public string CustomerAddressStateOrProvince { get; set; }
        public string CustomerAddressPostalCode { get; set; }
        public string CustomerAddressCountry { get; set; }
        public int? CustomerOrderCount { get; set; }
        public decimal? CustomerOrderTotal { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
