using System;
using System.Collections.Generic;
using System.Linq;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.VendorModels;
using SaintReverenceMVC.Services.ServiceContracts;

namespace SaintReverenceMVC.Services{
    public class VendorService : IVendorService{
        public bool CreateVendor(VendorCreate model){
            var entity = new Vendor{
                VendorName = model.VendorName,
                VendorEmail = model.VendorEmail,
                VendorWebsite = model.VendorWebsite,
                VendorPhone = model.VendorPhone,
                VendorAddressLine1 = model.VendorAddressLine1,
                VendorAddressLine2 = model.VendorAddressLine2,
                VendorAddressLine3 = model.VendorAddressLine3,
                VendorAddressCity = model.VendorAddressCity,
                VendorAddressStateOrProvince = model.VendorAddressStateOrProvince,
                VendorAddressCountry = model.VendorAddressCountry
            };

            using (var ctx = new src_backendContext()){
                ctx.Vendors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VendorListItem> GetAllVendors(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Vendors
                    .Select(vli => new VendorListItem{
                        VendorID = vli.VendorID,
                        VendorName = vli.VendorName,
                        VendorWebsite = vli.VendorWebsite,
                        VendorEmail = vli.VendorEmail
                    });

                return query.ToList().OrderBy(o => o.VendorName);
            }
        }

        public VendorDetail GetVendorByID(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Vendors.Find(id);

                return new VendorDetail{
                    VendorID = entity.VendorID,
                    VendorName = entity.VendorName,
                    VendorEmail = entity.VendorEmail,
                    VendorWebsite = entity.VendorWebsite,
                    VendorPhone = entity.VendorPhone,
                    VendorAddress = entity.VendorAddressLine1 + "\r" + entity.VendorAddressLine2 + "\r" + entity.VendorAddressLine3 + "\r" + entity.VendorAddressCity + ", " + entity.VendorAddressStateOrProvince + "  " + entity.VendorAddressPostalcode + "\r" + entity.VendorAddressCountry
                };
            }
        }

        public bool UpdateVendor(VendorEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Vendors.Find(model.VendorID);

                entity.VendorName = model.VendorName;
                entity.VendorEmail = model.VendorEmail;
                entity.VendorWebsite = model.VendorEmail;
                entity.VendorPhone = model.VendorPhone;
                entity.VendorAddressLine1 = model.VendorAddressLine1;
                entity.VendorAddressLine2 = model.VendorAddressLine2;
                entity.VendorAddressLine3 = model.VendorAddressLine3;
                entity.VendorAddressCity = model.VendorAddressCity;
                entity.VendorAddressStateOrProvince = model.VendorAddressStateOrProvince;
                entity.VendorAddressPostalcode = model.VendorAddressPostalCode;
                entity.VendorAddressCountry = model.VendorAddressCountry;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVendor(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Vendors.Find(id);
                ctx.Vendors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}