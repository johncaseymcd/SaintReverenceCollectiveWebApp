using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Permission
    {
        public Permission()
        {
            Employees = new HashSet<Employee>();
        }

        public int PermissionLevel { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
