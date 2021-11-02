using System;
using System.Collections.Generic;
using SaintReverenceMVC.Models.InvoiceModels;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IInvoiceService{
        Task<bool> CreateInvoiceAsync(InvoiceCreate model);
        Task<IEnumerable<InvoiceListItem>> GetAllInvoicesAsync();
        InvoiceDetail GetInvoiceByID(Guid id);
        Task<IEnumerable<InvoiceListItem>> GetInvoicesByPaidStatusAsync(bool status);
        Task<IEnumerable<InvoiceListItem>> GetInvoicesDueSoonAsync();
        Task<IEnumerable<InvoiceListItem>> GetOverdueInvoicesAsync();
        Task<IEnumerable<InvoiceListItem>> GetInvoicesByVendorIDAsync(int vendorID);
        Task<bool> UpdateInvoiceAsync(InvoiceEdit model);
        Task<bool> DeleteInvoiceAsync(Guid id);
    }
}