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

        public Task<IEnumerable<CollectionListItem>> DisplayAllCollections(){
            return await _collectionService.GetAllCollectionsAsync();
        }

        public Task<IEnumerable<CustomerListItem>> DisplayTopCustomers(){
            
        }
    }
}