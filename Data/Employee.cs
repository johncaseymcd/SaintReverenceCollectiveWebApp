using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Employee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime EmployeeBirthday { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeAddressLine1 { get; set; }
        public string EmployeeAddressLine2 { get; set; }
        public string EmployeeAddressLine3 { get; set; }
        public string EmployeeAddressCity { get; set; }
        public string EmployeeAddressStateOrProvince { get; set; }
        public string EmployeeAddressPostalCode { get; set; }
        public string EmployeeAddressCountry { get; set; }
        public string EmployeeSsnhash { get; set; }
        public decimal EmployeeSalaryPerYear { get; set; }
        public int EmployeeHoursPerWeek { get; set; }
        public bool EmployeeIsActive { get; set; }
        public int EmployeePermissionLevel { get; set; }

        public virtual Permission EmployeePermissionLevelNavigation { get; set; }
    }
}
