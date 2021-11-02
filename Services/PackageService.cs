using System;
using System.Collections.Generic;
using System.Linq;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.PackageModels;
using SaintReverenceMVC.Services.ServiceContracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaintReverenceMVC.Services{
    public class PackageService : IPackageService{
        public async Task<bool> CreatePackageAsync(PackageCreate model){
            var entity = new Package{
                PackageName = model.PackageName,
                PackageWeightInGrams = model.PackageWeightInGrams,
                PackageHeightInCentimeters = model.PackageHeightInCentimeters,
                PackageWidthInCentimeters = model.PackageWidthInCentimeters,
                PackageLengthInCentimeters = model.PackageLengthInCentimeters,
                PackageCostToShip = model.PackageCostToShip
            };

            using (var ctx = new src_backendContext()){
                ctx.Packages.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<PackageListItem>> GetAllPackagesAsync(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Packages
                    .Select(pli => new PackageListItem{
                        PackageID = pli.PackageID,
                        PackageName = pli.PackageName,
                        PackageCostToShip = pli.PackageCostToShip
                    })
                    .OrderBy(o => o.PackageCostToShip);

                return await query.ToListAsync();
            }
        }

        public PackageDetail GetPackageByID(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Packages.Find(id);

                return new PackageDetail{
                    PackageID = entity.PackageID,
                    PackageName = entity.PackageName,
                    PackageWeightInGrams = entity.PackageWeightInGrams,
                    PackageDimensionsInCentimeters = "W: " + entity.PackageWidthInCentimeters + "cm\r" + "L: " + entity.PackageLengthInCentimeters + "cm\r" + "H: " + entity.PackageHeightInCentimeters + "cm\r",
                    PackageCostToShip = entity.PackageCostToShip
                };
            }
        }

        public async Task<bool> UpdatePackageAsync(PackageEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Packages.Find(model.PackageID);

                entity.PackageCostToShip = model.PackageCostToShip;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeletePackageAsync(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Packages.Find(id);
                ctx.Packages.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}