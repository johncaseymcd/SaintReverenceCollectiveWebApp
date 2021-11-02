using SaintReverenceMVC.Models.CustomerModels;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface ICustomerService
    {
            Task<bool> CreateCustomerAsync(CustomerCreate model);
            Task<bool> DeleteCustomerAsync(Guid id);
            Task<IEnumerable<CustomerListItem>> GetAllCustomersAsync();
            CustomerDetail GetCustomerByID(Guid id);
            Task<IEnumerable<CustomerListItem>> GetCustomersByBirthdayAsync(DateTime birthday);
            Task<IEnumerable<CustomerListItem>> GetVIPCustomersAsync();
            Task<bool> UpdateCustomerAsync(CustomerEdit model);
            Task<bool> UpdateCustomerAsync(Guid id, CustomerEdit model);
    }
}