using System;
using System.Collections.Generic;
using System.Linq;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.ProductModels;
using SaintReverenceMVC.Services.ServiceContracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaintReverenceMVC.Models.OrderModels;

namespace SaintReverenceMVC.Services{
    public class ProductService : IProductService{
        public async Task<bool> CreateProductAsync(ProductCreate model){
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
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync(){
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
                    })
                    .OrderBy(o => o.CollectionID).ThenBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);

                return await query.ToListAsync();
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

        public async Task<IEnumerable<ProductListItem>> GetProductsByInStockAsync(){
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
                    })
                    .OrderBy(o => o.CollectionID).ThenBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<ProductListItem>> GetProductsByLowStockAsync(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Products
                    .Where(p => p.ProductInventoryCount <= (p.ProductMaxInventory * 0.2))
                    .Select(pli => new ProductListItem{
                        ProductID = pli.ProductID,
                        ProductName = pli.ProductName,
                        ProductSellPrice = pli.ProductSellPrice,
                        ProductInventoryCount = pli.ProductInventoryCount,
                        ProductMaxInventoryCount = pli.ProductMaxInventory,
                        ProductTurnaroundTime = pli.ProductTurnaroundTime,
                        CategoryID = pli.CategoryID,
                        CollectionID = pli.CollectionID
                    })
                    .OrderBy(p => p.ProductInventoryCount);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<ProductListItem>> GetProductsByStatusAsync(bool status){
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
                    })
                    .OrderBy(o => o.CollectionID).ThenBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<ProductListItem>> GetProductsByCategoryAsync(int categoryID){
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
                    })
                    .OrderBy(o => o.CollectionID).ThenBy(o => o.ProductSellPrice);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<ProductListItem>> GetProductsByCollectionAsync(int collectionID){
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
                    })
                    .OrderBy(o => o.CategoryID).ThenBy(o => o.ProductSellPrice);
                
                return await query.ToListAsync();
            }
        }

        public IEnumerable<OrderListItem> GetOrdersByProductID(int productID){
            using (var ctx = new src_backendContext()){
                var query = ctx.OrdersProducts
                    .Where(op => op.ProductID == productID);
                
                List<OrderListItem> orders = new();
                Order orderToAdd = new();
                foreach(var item in query){
                    orderToAdd = item.OrderNavigation;
                    orders.Add(new OrderListItem{
                        OrderID = orderToAdd.OrderID,
                        OrderDate = orderToAdd.OrderDate,
                        OrderStatus = orderToAdd.OrderStatus,
                        OrderTotal = orderToAdd.OrderTotal,
                        CustomerID = orderToAdd.CustomerID
                    });
                }
                return orders.OrderByDescending(o => o.OrderDate).ToList();
            }
        }

        public async Task<bool> AddProductToOrderAsync(int productID, Guid orderID){
            using (var ctx = new src_backendContext()){
                var order = ctx.Orders.Find(orderID);
                if (order is null) order = new Order();
                var product = ctx.Products.Find(productID);
                order.Products.Add(product);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateProductAsync(ProductEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Products.Find(model.ProductID);

                entity.ProductName = model.ProductName;
                entity.ProductDescription = model.ProductDescription;
                entity.ProductSellPrice = model.ProductSellPrice;
                entity.ProductInventoryCount = model.ProductInventoryCount;
                entity.ProductMaxInventory = model.ProductMaxInventoryCount;
                entity.ProductIsActive = model.ProductIsActive;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteProductAsync(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Products.Find(id);
                ctx.Products.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}