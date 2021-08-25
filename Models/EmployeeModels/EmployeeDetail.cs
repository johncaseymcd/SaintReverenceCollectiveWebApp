using System;

namespace SaintReverenceMVC.Models.EmployeeModels
{
    public class EmployeeDetail
    {
        public string EmployeeName { get; set; }
        public DateTime EmployeeBirthday { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public decimal EmployeeSalaryPerYear { get; set; }
        public int EmployeeHoursPerWeek { get; set; }
        public bool EmployeeIsActive { get; set; }
        public int EmployeePermissionLevel { get; set; }
    }
}