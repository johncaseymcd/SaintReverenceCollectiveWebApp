using System;
using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.OrderModels
{
    public class OrderCreate
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int OrderStatus { get; set; }
        [Required]
        public decimal OrderTotal { get; set; }
        [Required]
        public Guid CustomerID { get; set; }
        [Required]
        public int PackageID { get; set; }
    }
}