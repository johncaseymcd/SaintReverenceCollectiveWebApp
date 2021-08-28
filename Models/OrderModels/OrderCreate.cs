using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SaintReverenceMVC.Data;

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
        [Required]
        public List<Product> Products { get; set; }
    }
}