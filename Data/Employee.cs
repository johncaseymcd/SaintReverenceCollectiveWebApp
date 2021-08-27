﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Employee
    {
        [Key]
        public Guid EmployeeID { get; set; }
        [Required, MaxLength(50)]
        public string EmployeeFirstName { get; set; }
        [MaxLength(50)]
        public string EmployeeMiddleName { get; set; }
        [Required, MaxLength(50)]
        public string EmployeeLastName { get; set; }
        [Required]
        public DateTime EmployeeBirthday { get; set; }
        [Required, MaxLength(50), EmailAddress]
        public string EmployeeEmail { get; set; }
        [Required, MaxLength(25), Phone]
        public string EmployeePhone { get; set; }
        [Required, MaxLength(255)]
        public string EmployeeAddressLine1 { get; set; }
        [MaxLength(255)]
        public string EmployeeAddressLine2 { get; set; }
        [MaxLength(255)]
        public string EmployeeAddressLine3 { get; set; }
        [Required, MaxLength(255)]
        public string EmployeeAddressCity { get; set; }
        [Required, MaxLength(25)]
        public string EmployeeAddressStateOrProvince { get; set; }
        [Required, MaxLength(25)]
        public string EmployeeAddressPostalCode { get; set; }
        [Required, MaxLength(100)]
        public string EmployeeAddressCountry { get; set; }
        [Required, MaxLength(255)]
        public string EmployeeSSNHash { get; set; }
        [Required]
        public decimal EmployeeSalaryPerYear { get; set; }
        [Required, Range(0, 41)]
        public int EmployeeHoursPerWeek { get; set; }
        [Required]
        public bool EmployeeIsActive { get; set; }
        [ForeignKey(nameof(EmployeePermissionLevelNavigation))]
        public int EmployeePermissionLevel { get; set; }

        public virtual Permission EmployeePermissionLevelNavigation { get; set; }
    }
}
