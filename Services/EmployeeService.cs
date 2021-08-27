using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.EmployeeModels;
using System.Text;

namespace SaintReverenceMVC.Services
{
    public class EmployeeService
    {
        public bool CreateEmployee(EmployeeCreate model)
        {
            var hasher = HashAlgorithm.Create("SHA512");
            var entity = new Employee
            {
                EmployeeFirstName = model.EmployeeFirstName,
                EmployeeMiddleName = model.EmployeeMiddleName,
                EmployeeLastName = model.EmployeeLastName,
                EmployeeBirthday = model.EmployeeBirthday,
                EmployeeEmail = model.EmployeeEmail,
                EmployeePhone = model.EmployeePhone,
                EmployeeAddressLine1 = model.EmployeeAddressLine1,
                EmployeeAddressLine2 = model.EmployeeAddressLine2,
                EmployeeAddressLine3 = model.EmployeeAddressLine3,
                EmployeeAddressCity = model.EmployeeAddressCity,
                EmployeeAddressStateOrProvince = model.EmployeeAddressStateOrProvince,
                EmployeeAddressPostalCode = model.EmployeeAddressPostalCode,
                EmployeeAddressCountry = model.EmployeeAddressCountry,
                EmployeeSSNHash = GetHash(hasher, model.EmployeeSSN),
                EmployeeSalaryPerYear = model.EmployeeSalaryPerYear,
                EmployeeHoursPerWeek = model.EmployeeHoursPerWeek,
                EmployeeIsActive = model.EmployeeIsActive,
                EmployeePermissionLevel = model.EmployeePermissionLevel
            };

            using (var ctx = new src_backendContext()){
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetAllEmployees(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Employees
                    .Select(eli => new EmployeeListItem{
                        EmployeeName = eli.EmployeeFirstName + " " + eli.EmployeeMiddleName + " " + eli.EmployeeLastName,
                        EmployeeBirthday = eli.EmployeeBirthday,
                        EmployeeEmail = eli.EmployeeEmail,
                        EmployeePhone = eli.EmployeePhone,
                        EmployeeSalaryPerYear = eli.EmployeeSalaryPerYear,
                        EmployeeHoursPerWeek = eli.EmployeeHoursPerWeek,
                        EmployeeIsActive = eli.EmployeeIsActive,
                        EmployeePermissionLevel = eli.EmployeePermissionLevel
                    });

                return query.ToList().OrderByDescending(o => o.EmployeePermissionLevel).ThenBy(o => o.EmployeeName);
            }
        }

        public EmployeeDetail GetEmployeeByID(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Employees.Find(id);

                return new EmployeeDetail{
                    EmployeeID = entity.EmployeeID,
                    EmployeeName = entity.EmployeeFirstName + " " + entity.EmployeeMiddleName + " " + entity.EmployeeLastName,
                    EmployeeBirthday = entity.EmployeeBirthday,
                    EmployeeEmail = entity.EmployeeEmail,
                    EmployeePhone = entity.EmployeePhone,
                    EmployeeAddress = entity.EmployeeAddressLine1 + "\r" + entity.EmployeeAddressLine2 + "\r" + entity.EmployeeAddressLine3 + "\r" + entity.EmployeeAddressCity + ", " + entity.EmployeeAddressStateOrProvince + "  " + entity.EmployeeAddressPostalCode + "\r" + entity.EmployeeAddressCountry,
                    EmployeeSalaryPerYear = entity.EmployeeSalaryPerYear,
                    EmployeeHoursPerWeek = entity.EmployeeHoursPerWeek, 
                    EmployeeIsActive = entity.EmployeeIsActive,
                    EmployeePermissionLevel = entity.EmployeePermissionLevel
                };
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployeesByBirthday(DateTime birthday){
            using (var ctx = new src_backendContext()){
                var query = ctx.Employees
                    .Where(e => e.EmployeeBirthday == birthday)
                    .Select(eli => new EmployeeListItem{
                        EmployeeName = eli.EmployeeFirstName + " " + eli.EmployeeMiddleName + " " + eli.EmployeeLastName,
                        EmployeeBirthday = eli.EmployeeBirthday,
                        EmployeeEmail = eli.EmployeeEmail,
                        EmployeePhone = eli.EmployeePhone,
                        EmployeeSalaryPerYear = eli.EmployeeSalaryPerYear,
                        EmployeeHoursPerWeek = eli.EmployeeHoursPerWeek,
                        EmployeeIsActive = eli.EmployeeIsActive,
                        EmployeePermissionLevel = eli.EmployeePermissionLevel
                    });

                return query.ToList().OrderBy(o => o.EmployeeName);
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployeesByStatus(bool status){
            using (var ctx = new src_backendContext()){
                var query = ctx.Employees
                    .Where(e => e.EmployeeIsActive == status)
                    .Select(eli => new EmployeeListItem{
                        EmployeeName = eli.EmployeeFirstName + " " + eli.EmployeeMiddleName + " " + eli.EmployeeLastName,
                        EmployeeBirthday = eli.EmployeeBirthday,
                        EmployeeEmail = eli.EmployeeEmail,
                        EmployeePhone = eli.EmployeePhone,
                        EmployeeSalaryPerYear = eli.EmployeeSalaryPerYear,
                        EmployeeHoursPerWeek = eli.EmployeeHoursPerWeek,
                        EmployeeIsActive = eli.EmployeeIsActive,
                        EmployeePermissionLevel = eli.EmployeePermissionLevel
                    });

                return query.ToList().OrderByDescending(o => o.EmployeePermissionLevel).ThenBy(o => o.EmployeeName);
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployeesByPermissionLevel(int level){
            using (var ctx = new src_backendContext()){
                var query = ctx.Employees
                    .Where(e => e.EmployeePermissionLevel == level)
                    .Select(eli => new EmployeeListItem{
                        EmployeeName = eli.EmployeeFirstName + " " + eli.EmployeeMiddleName + " " + eli.EmployeeLastName,
                        EmployeeBirthday = eli.EmployeeBirthday,
                        EmployeeEmail = eli.EmployeeEmail,
                        EmployeePhone = eli.EmployeePhone,
                        EmployeeSalaryPerYear = eli.EmployeeSalaryPerYear,
                        EmployeeHoursPerWeek = eli.EmployeeHoursPerWeek,
                        EmployeeIsActive = eli.EmployeeIsActive,
                        EmployeePermissionLevel = eli.EmployeePermissionLevel
                    });

                return query.ToList().OrderByDescending(o => o.EmployeePermissionLevel).ThenBy(o => o.EmployeeName);
            }
        }

        public bool UpdateEmployee(EmployeeEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Employees.Find(model.EmployeeID);

                entity.EmployeeFirstName = model.EmployeeFirstName;
                entity.EmployeeMiddleName = model.EmployeeMiddleName;
                entity.EmployeeLastName = model.EmployeeLastName;
                entity.EmployeeLastName = model.EmployeeEmail;
                entity.EmployeePhone = model.EmployeePhone;
                entity.EmployeeAddressLine1 = model.EmployeeAddressLine1;
                entity.EmployeeAddressLine2 = model.EmployeeAddressLine2;
                entity.EmployeeAddressLine3 = model.EmployeeAddressLine3;
                entity.EmployeeAddressCity = model.EmployeeAddressCity;
                entity.EmployeeAddressStateOrProvince = model.EmployeeAddressStateOrProvince;
                entity.EmployeeAddressPostalCode = model.EmployeeAddressPostalCode;
                entity.EmployeeAddressCountry = model.EmployeeAddressCountry;
                entity.EmployeeSalaryPerYear = model.EmployeeSalaryPerYear;
                entity.EmployeeHoursPerWeek = model.EmployeeHoursPerWeek;
                entity.EmployeeIsActive = model.EmployeeIsActive;
                entity.EmployeePermissionLevel = model.EmployeePermissionLevel;

                return ctx.SaveChanges() == 1;
            }            
        }

        public bool DeleteEmployee(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Employees.Find(id);
                ctx.Employees.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Hash helper method
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sb = new StringBuilder();
            foreach (var b in data)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}