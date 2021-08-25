using System;
using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.CustomerModels
{
    public class CustomerCreate
    {
        [Required, MaxLength(50)]
        public string CustomerFirstName { get; set; }
        [MaxLength(50)]
        public string CustomerMiddleName { get; set; }
        [Required, MaxLength(50)]
        public string CustomerLastName { get; set; }
        [Required]
        public DateTime CustomerBirthday { get; set; }
        [Required, MaxLength(50), EmailAddress]
        public string CustomerEmail { get; set; }
        [Required, MaxLength(25), Phone]
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
        [Required, MaxLength(100)]
        public string CustomerAddressCountry { get; set; }
    }
}