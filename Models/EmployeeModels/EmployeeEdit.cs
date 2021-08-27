using System;
using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.EmployeeModels
{
    public class EmployeeEdit
    {
        public Guid EmployeeID { get; set; }
        [MaxLength(50)]
        public string EmployeeFirstName { get; set; }
        [MaxLength(50)]
        public string EmployeeMiddleName { get; set; }
        [MaxLength(50)]
        public string EmployeeLastName { get; set; }
        [MaxLength(50), EmailAddress]
        public string EmployeeEmail { get; set; }
        [MaxLength(50), Phone]
        public string EmployeePhone { get; set; }
        [MaxLength(255)]
        public string EmployeeAddressLine1 { get; set; }
        [MaxLength(255)]
        public string EmployeeAddressLine2 { get; set; }
        [MaxLength(255)]
        public string EmployeeAddressLine3 { get; set; }
        [MaxLength(255)]
        public string EmployeeAddressCity { get; set; }
        [MaxLength(25)]
        public string EmployeeAddressStateOrProvince { get; set; }
        [MaxLength(25)]
        public string EmployeeAddressPostalCode { get; set; }
        [MaxLength(100)]
        public string EmployeeAddressCountry { get; set; }
        public decimal EmployeeSalaryPerYear { get; set; }
        public int EmployeeHoursPerWeek { get; set; }
        public bool EmployeeIsActive { get; set; }
        public int EmployeePermissionLevel { get; set; }
    }
}