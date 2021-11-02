using System.Collections.Generic;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Models.CustomerModels;
using SaintReverenceMVC.Models.EmployeeModels;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Models.ProductModels;

namespace SaintReverenceMVC.Models.DashboardModels{
    public class DashboardViewModel{
        public IEnumerable<CollectionListItem> AllCollections { get; set; }
        public IEnumerable<CustomerListItem> TopCustomers { get; set; }
        public IEnumerable<EmployeeListItem> NewEmployees { get; set; }
        public IEnumerable<InvoiceListItem> UnpaidInvoices { get; set; }
        public IEnumerable<OrderListItem> UnfulfilledOrders { get; set; }
        public IEnumerable<ProductListItem> LowInventoryProducts { get; set; }

        public virtual ICollection<Vendor> Vendors { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}