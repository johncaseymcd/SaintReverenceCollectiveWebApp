using System;
using System.Linq;
using System.Collections.Generic;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.CustomerModels;

namespace SaintReverenceMVC.Services
{
    public class CustomerService
    {
        private readonly Guid _userID;
        public CustomerService(Guid userID){
            _userID = userID;
        }

        public bool CreateCustomer(CustomerCreate model){
            var entity = new Customer{
                CustomerFirstName = model.CustomerFirstName,
                CustomerMiddleName = model.CustomerMiddleName,
                CustomerLastName = model.CustomerLastName,
                CustomerBirthday = model.CustomerBirthday,
                CustomerEmail = model.CustomerEmail,
                CustomerPhone = model.CustomerPhone,
                CustomerAddressLine1 = model.CustomerAddressLine1,
                CustomerAddressLine2 = model.CustomerAddressLine2, 
                CustomerAddressLine3 = model.CustomerAddressLine3, 
                CustomerAddressCity = model.CustomerAddressCity,
                CustomerAddressStateOrProvince = model.CustomerAddressStateOrProvince,
                CustomerAddressPostalCode = model.CustomerAddressPostalCode,
                CustomerAddressCountry = model.CustomerAddressCountry
            };

            using (var ctx = new src_backendContext()){
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetAllCustomers(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Customers
                    .Select(cli => new CustomerListItem{
                        CustomerID = cli.CustomerID,
                        CustomerName = cli.CustomerFirstName + " " + cli.CustomerMiddleName + " " + cli.CustomerLastName,
                        CustomerBirthday = cli.CustomerBirthday,
                        CustomerEmail = cli.CustomerEmail,
                        CustomerOrderCount = cli.CustomerOrderCount,
                        CustomerOrderTotal = cli.CustomerOrderTotal
                    });

                return query.ToList().OrderBy(o => o.CustomerName);
            }
        }

        public CustomerDetail GetCustomerByID(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Customers.Find(id);
                var total = 0.00m;
                foreach(var order in entity.Orders){
                    total += order.OrderTotal;
                }

                return new CustomerDetail{
                    CustomerID = entity.CustomerID,
                    CustomerName = entity.CustomerFirstName + " " + entity.CustomerMiddleName + " " + entity.CustomerLastName,
                    CustomerBirthday = entity.CustomerBirthday,
                    CustomerEmail = entity.CustomerEmail,
                    CustomerPhone = entity.CustomerPhone,
                    CustomerAddress = entity.CustomerAddressLine1 + "\r" + entity.CustomerAddressLine2 + "\r" + entity.CustomerAddressLine3 + "\r" + entity.CustomerAddressCity + ", " + entity.CustomerAddressStateOrProvince + "  " + entity.CustomerAddressPostalCode + "\r" + entity.CustomerAddressCountry,
                    CustomerOrderCount = entity.Orders.Count,
                    CustomerOrderTotal = total
                };
            }
        }

        public IEnumerable<CustomerListItem> GetCustomersByBirthday(DateTime birthday){
            using (var ctx = new src_backendContext()){
                var query = ctx.Customers
                    .Where(c => c.CustomerBirthday == birthday)
                    .Select(cli => new CustomerListItem{
                        CustomerID = cli.CustomerID,
                        CustomerName = cli.CustomerFirstName + " " + cli.CustomerMiddleName + " " + cli.CustomerLastName,
                        CustomerBirthday = cli.CustomerBirthday,
                        CustomerEmail = cli.CustomerEmail,
                        CustomerOrderCount = cli.CustomerOrderCount,
                        CustomerOrderTotal = cli.CustomerOrderTotal
                    });

                return query.ToList().OrderBy(o => o.CustomerName);
            }
        }

        public IEnumerable<CustomerListItem> GetVIPCustomers(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Customers
                    .Where(c => c.CustomerOrderTotal > 1000.00m)
                    .Select(cli => new CustomerListItem{
                        CustomerID = cli.CustomerID,
                        CustomerName = cli.CustomerFirstName + " " + cli.CustomerMiddleName + " " + cli.CustomerLastName,
                        CustomerBirthday = cli.CustomerBirthday,
                        CustomerEmail = cli.CustomerEmail,
                        CustomerOrderCount = cli.CustomerOrderCount,
                        CustomerOrderTotal = cli.CustomerOrderTotal
                    });

                return query.ToList().OrderByDescending(o => o.CustomerOrderTotal);
            }
        }

        public bool UpdateCustomer(CustomerEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Customers.Find(model.CustomerID);

                entity.CustomerFirstName = model.CustomerFirstName;
                entity.CustomerMiddleName = model.CustomerMiddleName;
                entity.CustomerLastName = model.CustomerLastName;
                entity.CustomerEmail = model.CustomerEmail;
                entity.CustomerPhone = model.CustomerPhone;
                entity.CustomerAddressLine1 = model.CustomerAddressLine1;
                entity.CustomerAddressLine2 = model.CustomerAddressLine2;
                entity.CustomerAddressLine3 = model.CustomerAddressLine3;
                entity.CustomerAddressCity = model.CustomerAddressCity;
                entity.CustomerAddressStateOrProvince = model.CustomerAddressStateOrProvince;
                entity.CustomerAddressPostalCode = model.CustomerAddressPostalCode;
                entity.CustomerAddressCountry = model.CustomerAddressCountry;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCustomer(Guid id, CustomerEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Customers.Single(c => c.CustomerID == id && id == model.CustomerID);

                entity.CustomerFirstName = model.CustomerFirstName;
                entity.CustomerMiddleName = model.CustomerMiddleName;
                entity.CustomerLastName = model.CustomerLastName;
                entity.CustomerEmail = model.CustomerEmail;
                entity.CustomerPhone = model.CustomerPhone;
                entity.CustomerAddressLine1 = model.CustomerAddressLine1;
                entity.CustomerAddressLine2 = model.CustomerAddressLine2;
                entity.CustomerAddressLine3 = model.CustomerAddressLine3;
                entity.CustomerAddressCity = model.CustomerAddressCity;
                entity.CustomerAddressStateOrProvince = model.CustomerAddressStateOrProvince;
                entity.CustomerAddressPostalCode = model.CustomerAddressPostalCode;
                entity.CustomerAddressCountry = model.CustomerAddressCountry;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Customers.Find(id);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}