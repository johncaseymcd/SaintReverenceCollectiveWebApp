using System.Collections.Generic;
using SaintReverenceMVC.Data;

namespace SaintReverenceMVC.Models.DashboardModels{
    public class DashboardViewModel{
        public ICollection<Collection> AllCollections { get; set; }
        public ICollection<Customer> TopCustomers { get; set; }
        public ICollection<Employee> NewEmployees { get; set; }
        public ICollection<Invoice> UnpaidInvoices { get; set; }
        public ICollection<Order> UnfulfilledOrders { get; set; }
        public ICollection<Product> LowInventoryProducts { get; set; }
    }
}