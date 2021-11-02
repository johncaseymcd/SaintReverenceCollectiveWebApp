using SaintReverenceMVC.Services;
using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Models.CustomerModels;
using SaintReverenceMVC.Models.EmployeeModels;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Models.ProductModels;
using System.Collections.Generic;
using SaintReverenceMVC.Services.ServiceContracts;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services{
    public class DashboardService : IDashboardService{
        private readonly ICollectionService _collectionService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public DashboardService(ICollectionService collectionService, ICustomerService customerService, IEmployeeService employeeService, IInvoiceService invoiceService, IOrderService orderService, IProductService productService){
            _collectionService = collectionService;
            _customerService = customerService;
            _employeeService = employeeService;
            _invoiceService = invoiceService;
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IEnumerable<CollectionListItem>> DisplayAllCollectionsAsync(){
            return await _collectionService.GetAllCollectionsAsync();
        }

        public async Task<IEnumerable<CustomerListItem>> DisplayTopCustomersAsync(){
            return await _customerService.GetVIPCustomersAsync();
        }

        public async Task<IEnumerable<EmployeeListItem>> DisplayNewEmployeesAsync(){
            return await _employeeService.GetNewEmployeesAsync();
        }

        public async Task<IEnumerable<InvoiceListItem>> DisplayUnpaidInvoicesAsync(){
            return await _invoiceService.GetInvoicesByPaidStatusAsync(false);
        }

        public async Task<IEnumerable<OrderListItem>> DisplayUnfulfilledOrdersAsync(){
            return await _orderService.GetUnfulfilledOrdersAsync();
        }

        public async Task<IEnumerable<ProductListItem>> DisplayLowInventoryProductsAsync(){
            return await _productService.GetProductsByLowStockAsync();
        }
    }
}