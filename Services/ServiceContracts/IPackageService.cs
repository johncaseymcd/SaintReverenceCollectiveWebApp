using System.Collections.Generic;
using SaintReverenceMVC.Models.PackageModels;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IPackageService{
        Task<bool> CreatePackageAsync(PackageCreate model);
        Task<IEnumerable<PackageListItem>> GetAllPackagesAsync();
        PackageDetail GetPackageByID(int id);
        Task<bool> UpdatePackageAsync(PackageEdit model);
        Task<bool> DeletePackageAsync(int id);
    }
}