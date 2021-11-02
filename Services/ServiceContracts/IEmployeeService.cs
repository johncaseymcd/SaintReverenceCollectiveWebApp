using System;
using System.Collections.Generic;
using SaintReverenceMVC.Models.EmployeeModels;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IEmployeeService{
        Task<bool> CreateEmployeeAsync(EmployeeCreate model);
        Task<IEnumerable<EmployeeListItem>> GetAllEmployeesAsync();
        EmployeeDetail GetEmployeeByID(Guid id);
        Task<IEnumerable<EmployeeListItem>> GetEmployeesByBirthdayAsync(DateTime birthday);
        Task<IEnumerable<EmployeeListItem>> GetEmployeesByStatusAsync(bool status);
        Task<IEnumerable<EmployeeListItem>> GetEmployeesByPermissionLevelAsync(int level);
        Task<IEnumerable<EmployeeListItem>> GetNewEmployeesAsync();
        Task<bool> UpdateEmployeeAsync(EmployeeEdit model);
        Task<bool> DeleteEmployeeAsync(Guid id);
    }
}