using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public Guid CustomerID { get; set; }
        [Required, MaxLength(50)]
        public string CustomerFirstName { get; set; }
        [MaxLength(50)]
        public string CustomerMiddleName { get; set; }
        [Required, MaxLength(50)]
        public string CustomerLastName { get; set; }
        public DateTime CustomerBirthday { get; set; }
        [Required, MaxLength(50)]
        public string CustomerEmail { get; set; }
        [Required, MaxLength(25)]
        public string CustomerPhone { get; set; }
        [Required, MaxLength(255)]
        public string CustomerAddressLine1 { get; set; }
        [MaxLength(255)]
        public string CustomerAddressLine2 { get; set; }
        [MaxLength(255)]
        public string CustomerAddressLine3 { get; set; }
        [Required, MaxLength(255)]
        public string CustomerAddressCity { get; set; }
        [Required, MaxLength(25)]
        public string CustomerAddressStateOrProvince { get; set; }
        [Required, MaxLength(25)]
        public string CustomerAddressPostalCode { get; set; }
        [Required, MaxLength(100)]
        public string CustomerAddressCountry { get; set; }
        public int CustomerOrderCount { get; set; }
        public decimal CustomerOrderTotal { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
