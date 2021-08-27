using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.VendorModels
{
    public class VendorEdit
    {
        public int VendorID { get; set; }
        [MaxLength(100)]
        public string VendorName { get; set; }
        [MaxLength(50), EmailAddress]
        public string VendorEmail { get; set; }
        [MaxLength(50)]
        public string VendorWebsite { get; set; }
        [MaxLength(25), Phone]
        public string VendorPhone { get; set; }
        [MaxLength(255)]
        public string VendorAddressLine1 { get; set; }
        [MaxLength(255)]
        public string VendorAddressLine2 { get; set; }
        [MaxLength(255)]
        public string VendorAddressLine3 { get; set; }
        [MaxLength(255)]
        public string VendorAddressCity { get; set; }
        [MaxLength(25)]
        public string VendorAddressStateOrProvince { get; set; }
        [MaxLength(25)]
        public string VendorAddressPostalCode { get; set; }
        [MaxLength(100)]
        public string VendorAddressCountry { get; set; }
    }
}