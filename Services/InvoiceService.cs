using System;
using System.Linq;
using System.Collections.Generic;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.InvoiceModels;

namespace SaintReverenceMVC.Services
{
    public class InvoiceService
    {
        public bool CreateInvoice(InvoiceCreate model){
            var entity = new Invoice{
                CostOfProducts = model.CostOfProducts,
                TaxPaid = model.TaxPaid,
                ShippingPaid = model.ShippingPaid,
                AdditionalFees = model.AdditionalFees,
                CreateDate = model.CreateDate,
                DueDate = model.DueDate,
                InvoiceIsPaid = model.InvoiceIsPaid,
                PaidDate = model.PaidDate,
                VendorID = model.VendorID
            };

            using (var ctx = new src_backendContext()){
                ctx.Invoices.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InvoiceListItem> GetAllInvoices(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    });

                return query.ToList().OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);
            }
        }

        public InvoiceDetail GetInvoiceByID(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Invoices.Find(id);
                
                return new InvoiceDetail{
                    InvoiceID = entity.InvoiceID,
                    TotalCost = entity.CostOfProducts + entity.TaxPaid + entity.ShippingPaid + entity.AdditionalFees,
                    TaxPaid = entity.TaxPaid,
                    CreateDate = entity.CreateDate,
                    DueDate = entity.DueDate,
                    InvoiceIsPaid = entity.InvoiceIsPaid,
                    PaidDate = entity.PaidDate,
                    VendorID = entity.VendorID
                };
            }
        }

        public IEnumerable<InvoiceListItem> GetInvoicesByPaidStatus(bool status){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Where(i => i.InvoiceIsPaid == status)
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    });

                return query.ToList().OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);
            }
        }

        public IEnumerable<InvoiceListItem> GetInvoicesDueSoon(DateTime twoWeeks){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Where(i => i.DueDate <= twoWeeks)
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    });

                return query.ToList().OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);
            }
        }

        public IEnumerable<InvoiceListItem> GetOverdueInvoices(DateTime currentDate){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Where(i => i.DueDate <= currentDate && i.InvoiceIsPaid == false)
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    });

                return query.ToList().OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);
            }
        }

        public IEnumerable<InvoiceListItem> GetInvoicesByVendorID(int id){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Where(i => i.VendorID == id)
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    });

                return query.ToList().OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);
            }
        }

        public bool UpdateInvoice(InvoiceEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Invoices.Find(model.InvoiceID);

                entity.InvoiceID = model.InvoiceID;
                entity.InvoiceIsPaid = model.InvoiceIsPaid;
                entity.PaidDate = model.PaidDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInvoice(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Invoices.Find(id);
                ctx.Invoices.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}