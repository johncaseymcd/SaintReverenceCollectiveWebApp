using System.Collections.Generic;
using SaintReverenceMVC.Models.VendorModels;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IVendorService{
        Task<bool> CreateVendorAsync(VendorCreate model);
        Task<IEnumerable<VendorListItem>> GetAllVendorsAsync();
        VendorDetail GetVendorByID(int id);
        Task<bool> UpdateVendorAsync(VendorEdit model);
        Task<bool> DeleteVendorAsync(int id);
    }
}