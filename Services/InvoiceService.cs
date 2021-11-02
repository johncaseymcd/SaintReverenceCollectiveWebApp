using System;
using System.Linq;
using System.Collections.Generic;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.InvoiceModels;
using SaintReverenceMVC.Services.ServiceContracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaintReverenceMVC.Services
{
    public class InvoiceService : IInvoiceService
    {
        public async Task<bool> CreateInvoiceAsync(InvoiceCreate model){
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
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<InvoiceListItem>> GetAllInvoicesAsync(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    })
                    .OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);

                return await query.ToListAsync();
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

        public async Task<IEnumerable<InvoiceListItem>> GetInvoicesByPaidStatusAsync(bool status){
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
                    })
                    .OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<InvoiceListItem>> GetInvoicesDueSoonAsync(){
            using (var ctx = new src_backendContext()){
                var twoWeeks = DateTime.Now.AddDays(14);
                var query = ctx.Invoices
                    .Where(i => i.DueDate <= twoWeeks)
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    })
                    .OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<InvoiceListItem>> GetOverdueInvoicesAsync(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Where(i => i.DueDate <= DateTime.Now && i.InvoiceIsPaid == false)
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    })
                    .OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<InvoiceListItem>> GetInvoicesByVendorIDAsync(int vendorID){
            using (var ctx = new src_backendContext()){
                var query = ctx.Invoices
                    .Where(i => i.VendorID == vendorID)
                    .Select(ili => new InvoiceListItem{
                        InvoiceID = ili.InvoiceID,
                        TotalCost = ili.CostOfProducts + ili.TaxPaid + ili.ShippingPaid + ili.AdditionalFees,
                        DueDate = ili.DueDate,
                        InvoiceIsPaid = ili.InvoiceIsPaid,
                        PaidDate = ili.PaidDate,
                        VendorID = ili.VendorID
                    })
                    .OrderBy(o => o.DueDate).ThenByDescending(o => o.TotalCost);

                return await query.ToListAsync();
            }
        }

        public async Task<bool> UpdateInvoiceAsync(InvoiceEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Invoices.Find(model.InvoiceID);

                entity.InvoiceID = model.InvoiceID;
                entity.InvoiceIsPaid = model.InvoiceIsPaid;
                entity.PaidDate = model.PaidDate;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteInvoiceAsync(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Invoices.Find(id);
                ctx.Invoices.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}