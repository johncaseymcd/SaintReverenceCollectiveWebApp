using SaintReverenceMVC.Models.CustomerModels;
using System.Collections.Generic;
using System;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface ICustomerService
    {
            bool CreateCustomer(CustomerCreate model);
            bool DeleteCustomer(Guid id);
            IEnumerable<CustomerListItem> GetAllCustomers();
            CustomerDetail GetCustomerByID(Guid id);
            IEnumerable<CustomerListItem> GetCustomersByBirthday(DateTime birthday);
            IEnumerable<CustomerListItem> GetVIPCustomers();
            bool UpdateCustomer(CustomerEdit model);
            bool UpdateCustomer(Guid id, CustomerEdit model);
    }
}