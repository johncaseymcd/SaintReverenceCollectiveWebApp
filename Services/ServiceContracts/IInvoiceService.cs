using System;
using System.Collections.Generic;
using SaintReverenceMVC.Models.InvoiceModels;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IInvoiceService{
        bool CreateInvoice(InvoiceCreate model);
        IEnumerable<InvoiceListItem> GetAllInvoices();
        InvoiceDetail GetInvoiceByID(Guid id);
        IEnumerable<InvoiceListItem> GetInvoicesByPaidStatus(bool status);
        IEnumerable<InvoiceListItem> GetInvoicesDueSoon();
        IEnumerable<InvoiceListItem> GetOverdueInvoices();
        IEnumerable<InvoiceListItem> GetInvoicesByVendorID(int vendorID);
        bool UpdateInvoice(InvoiceEdit model);
        bool DeleteInvoice(Guid id);
    }
}