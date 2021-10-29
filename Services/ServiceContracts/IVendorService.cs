using System.Collections.Generic;
using SaintReverenceMVC.Models.VendorModels;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IVendorService{
        bool CreateVendor(VendorCreate model);
        IEnumerable<VendorListItem> GetAllVendors();
        VendorDetail GetVendorByID(int id);
        bool UpdateVendor(VendorEdit model);
        bool DeleteVendor(int id);
    }
}