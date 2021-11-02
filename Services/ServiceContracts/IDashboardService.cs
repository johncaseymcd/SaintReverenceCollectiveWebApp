using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Models.CustomerModels;
using SaintReverenceMVC.Models.EmployeeModels;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Models.ProductModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IDashboardService{
        Task<IEnumerable<CollectionListItem>> DisplayAllCollectionsAsync();
        Task<IEnumerable<CustomerListItem>> DisplayTopCustomersAsync();
        Task<IEnumerable<EmployeeListItem>> DisplayNewEmployeesAsync();
        Task<IEnumerable<InvoiceListItem>> DisplayUnpaidInvoicesAsync();
        Task<IEnumerable<OrderListItem>> DisplayUnfulfilledOrdersAsync();
        Task<IEnumerable<ProductListItem>> DisplayLowInventoryProductsAsync();
    }
}