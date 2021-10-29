using System.Collections.Generic;
using SaintReverenceMVC.Models.ProductModels;
using System;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IProductService{
        bool CreateProduct(ProductCreate model);
        IEnumerable<ProductListItem> GetAllProducts();
        ProductDetail GetProductByID(int id);
        IEnumerable<ProductListItem> GetProductsByInStock();
        IEnumerable<ProductListItem> GetProductsByStatus(bool status);
        IEnumerable<ProductListItem> GetProductsByCategory(int categoryID);
        IEnumerable<ProductListItem> GetProductsByCollection(int collectionID);
        bool AddProductToOrder(int productID, Guid orderID);
        bool UpdateProduct(ProductEdit model);
        bool DeleteProduct(int id);
    }
}