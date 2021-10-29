using System;
using System.Collections.Generic;
using SaintReverenceMVC.Models.EmployeeModels;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IEmployeeService{
        bool CreateEmployee(EmployeeCreate model);
        IEnumerable<EmployeeListItem> GetAllEmployees();
        EmployeeDetail GetEmployeeByID(Guid id);
        IEnumerable<EmployeeListItem> GetEmployeesByBirthday(DateTime birthday);
        IEnumerable<EmployeeListItem> GetEmployeesByStatus(bool status);
        IEnumerable<EmployeeListItem> GetEmployeesByPermissionLevel(int level);
        bool UpdateEmployee(EmployeeEdit model);
        bool DeleteEmployee(Guid id);
    }
}