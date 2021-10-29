using System.Collections.Generic;
using SaintReverenceMVC.Models.PackageModels;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IPackageService{
        bool CreatePackage(PackageCreate model);
        IEnumerable<PackageListItem> GetAllPackages();
        PackageDetail GetPackageByID(int id);
        bool UpdatePackage(PackageEdit model);
        bool DeletePackage(int id);
    }
}