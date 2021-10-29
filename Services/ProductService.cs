using System;
using System.Collections.Generic;
using System.Linq;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.ProductModels;
using SaintReverenceMVC.Services.ServiceContracts;

namespace SaintReverenceMVC.Services{
    public class ProductService : IProductService{
        public bool CreateProduct(ProductCreate model){
            var entity = new Product{
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductBuyCost = model.ProductBuyCost,
                ProductSellPrice = model.ProductSellPrice,
                ProductInventoryCount = model.ProductInventoryCount,
                ProductMaxInventory = model.ProductMaxInventoryCount,
                ProductTurnaroundTime = model.ProductTurnaroundTime,
                ProductWeightInGrams = model.ProductWeightInGrams,
                ProductIsActive = model.ProductIsActive,
                CategoryID = model.CategoryID,
                CollectionID = model.CollectionID,
                PackageID = model.PackageID,
                VendorID = model.VendorID
            };

            using (var ctx = new src_backendContext()){
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetAllProducts(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Products
                    .Select(pli => new ProductListItem{
                        ProductID = pli.ProductID,
                        ProductName = pli.ProductName,
                        ProductSellPrice = pli.ProductSellPrice,
                        ProductInventoryCount = pli.ProductInventoryCount,
                        ProductMaxInventoryCount = pli.ProductMaxInventory,
                        ProductTurnaroundTime = pli.ProductTurnaroundTime,
                        CategoryID = pli.CategoryID,
                        CollectionID = pli.CollectionID
                    });

                return query.ToList().OrderBy(o => o.CollectionID).ThenBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);
            }
        }

        public ProductDetail GetProductByID(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Products.Find(id);

                return new ProductDetail{
                    ProductID = entity.ProductID,
                    ProductName = entity.ProductName,
                    ProductDescription = entity.ProductDescription,
                    ProductBuyCost = entity.ProductBuyCost,
                    ProductSellPrice = entity.ProductSellPrice,
                    ProductInventoryCount = entity.ProductInventoryCount,
                    ProductMaxInventoryCount = entity.ProductMaxInventory,
                    ProductWeightInGrams = entity.ProductWeightInGrams,
                    ProductIsActive = entity.ProductIsActive,
                    CategoryID = entity.CategoryID,
                    CollectionID = entity.CollectionID,
                    VendorID = entity.VendorID
                };
            }
        }

        public IEnumerable<ProductListItem> GetProductsByInStock(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Products
                    .Where(p => p.ProductInventoryCount > 0)
                    .Select(pli => new ProductListItem{
                        ProductID = pli.ProductID,
                        ProductName = pli.ProductName,
                        ProductSellPrice = pli.ProductSellPrice,
                        ProductInventoryCount = pli.ProductInventoryCount,
                        ProductMaxInventoryCount = pli.ProductMaxInventory,
                        ProductTurnaroundTime = pli.ProductTurnaroundTime,
                        CategoryID = pli.CategoryID,
                        CollectionID = pli.CollectionID
                    });

                return query.ToList().OrderBy(o => o.CollectionID).ThenBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);
            }
        }

        public IEnumerable<ProductListItem> GetProductsByStatus(bool status){
            using (var ctx = new src_backendContext()){
                var query = ctx.Products
                    .Where(p => p.ProductIsActive == status)
                    .Select(pli => new ProductListItem{
                        ProductID = pli.ProductID,
                        ProductName = pli.ProductName,
                        ProductSellPrice = pli.ProductSellPrice,
                        ProductInventoryCount = pli.ProductInventoryCount,
                        ProductMaxInventoryCount = pli.ProductMaxInventory,
                        ProductTurnaroundTime = pli.ProductTurnaroundTime,
                        CategoryID = pli.CategoryID,
                        CollectionID = pli.CollectionID
                    });

                return query.ToList().OrderBy(o => o.CollectionID).ThenBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);
            }
        }

        public IEnumerable<ProductListItem> GetProductsByCategory(int categoryID){
            using (var ctx = new src_backendContext()){
                var query = ctx.Products
                    .Where(p => p.CategoryID == categoryID)
                    .Select(pli => new ProductListItem{
                        ProductID = pli.ProductID,
                        ProductName = pli.ProductName,
                        ProductSellPrice = pli.ProductSellPrice,
                        ProductInventoryCount = pli.ProductInventoryCount,
                        ProductMaxInventoryCount = pli.ProductMaxInventory,
                        ProductTurnaroundTime = pli.ProductTurnaroundTime,
                        CategoryID = pli.CategoryID,
                        CollectionID = pli.CollectionID
                    });

                return query.ToList().OrderBy(o => o.CollectionID).ThenBy(o => o.ProductSellPrice);
            }
        }

        public IEnumerable<ProductListItem> GetProductsByCollection(int collectionID){
            using (var ctx = new src_backendContext()){
                var query = ctx.Products
                    .Where(p => p.CollectionID == collectionID)
                    .Select(pli => new ProductListItem{
                        ProductID = pli.ProductID,
                        ProductName = pli.ProductName,
                        ProductSellPrice = pli.ProductSellPrice,
                        ProductInventoryCount = pli.ProductInventoryCount,
                        ProductMaxInventoryCount = pli.ProductMaxInventory,
                        ProductTurnaroundTime = pli.ProductTurnaroundTime,
                        CategoryID = pli.CategoryID,
                        CollectionID = pli.CollectionID
                    });
                
                return query.ToList().OrderBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);
            }
        }

        public bool AddProductToOrder(int productID, Guid orderID){
            using (var ctx = new src_backendContext()){
                var order = ctx.Orders.Find(orderID);
                if (order is null) order = new Order();
                var product = ctx.Products.Find(productID);
                if (product != null){
                    order.Products.Add(product);
                    return true;
                }
                else{
                    return false;
                }
            }
        }

        public bool UpdateProduct(ProductEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Products.Find(model.ProductID);

                entity.ProductName = model.ProductName;
                entity.ProductDescription = model.ProductDescription;
                entity.ProductSellPrice = model.ProductSellPrice;
                entity.ProductInventoryCount = model.ProductInventoryCount;
                entity.ProductMaxInventory = model.ProductMaxInventoryCount;
                entity.ProductIsActive = model.ProductIsActive;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Products.Find(id);
                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}