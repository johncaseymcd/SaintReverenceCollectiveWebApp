using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Permission
    {
        public Permission()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int PermissionLevel { get; set; }
        [Required, MaxLength(100)]
        public string PermissionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
