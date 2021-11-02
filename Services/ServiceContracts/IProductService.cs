using System.Collections.Generic;
using SaintReverenceMVC.Models.ProductModels;
using System;
using SaintReverenceMVC.Models.OrderModels;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IProductService{
        Task<bool> CreateProductAsync(ProductCreate model);
        Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
        ProductDetail GetProductByID(int id);
        Task<IEnumerable<ProductListItem>> GetProductsByInStockAsync();
        Task<IEnumerable<ProductListItem>> GetProductsByLowStockAsync();
        Task<IEnumerable<ProductListItem>> GetProductsByStatusAsync(bool status);
        Task<IEnumerable<ProductListItem>> GetProductsByCategoryAsync(int categoryID);
        Task<IEnumerable<ProductListItem>> GetProductsByCollectionAsync(int collectionID);
        IEnumerable<OrderListItem> GetOrdersByProductID(int productID);
        Task<bool> AddProductToOrderAsync(int productID, Guid orderID);
        Task<bool> UpdateProductAsync(ProductEdit model);
        Task<bool> DeleteProductAsync(int id);
    }
}