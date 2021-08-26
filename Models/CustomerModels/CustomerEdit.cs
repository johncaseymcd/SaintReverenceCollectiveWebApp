using System;
using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.CustomerModels
{
    public class CustomerEdit
    {
        public Guid CustomerID { get; set; }
        [MaxLength(50)]
        public string CustomerFirstName { get; set; }
        [MaxLength(50)]
        public string CustomerMiddleName { get; set; }
        [MaxLength(50)]
        public string CustomerLastName { get; set; }
        [MaxLength(50), EmailAddress]
        public string CustomerEmail { get; set; }
        [MaxLength(25), Phone]
        public string CustomerPhone { get; set; }
        [MaxLength(255)]
        public string CustomerAddressLine1 { get; set; }
        [MaxLength(255)]
        public string CustomerAddressLine2 { get; set; }
        [MaxLength(255)]
        public string CustomerAddressLine3 { get; set; }
        [MaxLength(255)]
        public string CustomerAddressCity { get; set; }
        [MaxLength(25)]
        public string CustomerAddressStateOrProvince { get; set; }
        [MaxLength(25)]
        public string CustomerAddressPostalCode { get; set; }
        [MaxLength(100)]
        public string CustomerAddressCountry { get; set; }
    }
}