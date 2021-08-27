using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int StatusID { get; set; }
        [Required, MaxLength(100)]
        public string StatusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
