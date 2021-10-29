using SaintReverenceMVC.Services;
using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Models.CustomerModels;
using SaintReverenceMVC.Models.EmployeeModels;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Models.ProductModels;
using System.Collections.Generic;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IDashboardService{
        IEnumerable<CollectionListItem> DisplayAllCollections();
        IEnumerable<CustomerListItem> DisplayTopCustomers();
        IEnumerable<EmployeeListItem> DisplayNewEmployees();
        IEnumerable<InvoiceListItem> DisplayUnpaidInvoices();
        IEnumerable<OrderListItem> DisplayUnfulfilledOrders();
        IEnumerable<ProductListItem> DisplayLowInventoryProducts();
    }
}