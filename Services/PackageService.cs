using System;
using System.Collections.Generic;
using System.Linq;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.PackageModels;

namespace SaintReverenceMVC.Services{
    public class PackageService{
        public bool CreatePackage(PackageCreate model){
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
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PackageListItem> GetAllPackages(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Packages
                    .Select(pli => new PackageListItem{
                        PackageID = pli.PackageID,
                        PackageName = pli.PackageName,
                        PackageCostToShip = pli.PackageCostToShip
                    });

                return query.ToList().OrderBy(o => o.PackageCostToShip);
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

        public bool UpdatePackage(PackageEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Packages.Find(model.PackageID);

                entity.PackageCostToShip = model.PackageCostToShip;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePackage(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Packages.Find(id);
                ctx.Packages.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}