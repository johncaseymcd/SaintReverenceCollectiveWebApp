using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.VendorModels
{
    public class VendorCreate
    {
        [Required, MaxLength(100)]
        public string VendorName { get; set; }
        [Required, MaxLength(50), EmailAddress]
        public string VendorEmail { get; set; }
        [Required, MaxLength(50)]
        public string VendorWebsite { get; set; }
        [Required, MaxLength(25), Phone]
        public string VendorPhone { get; set; }
        [Required, MaxLength(255)]
        public string VendorAddressLine1 { get; set; }
        [MaxLength(255)]
        public string VendorAddressLine2 { get; set; }
        [MaxLength(255)]
        public string VendorAddressLine3 { get; set; }
        [Required, MaxLength(255)]
        public string VendorAddressCity { get; set; }
        [Required, MaxLength(25)]
        public string VendorAddressStateOrProvince { get; set; }
        [Required, MaxLength(100)]
        public string VendorAddressCountry { get; set; }
    }
}