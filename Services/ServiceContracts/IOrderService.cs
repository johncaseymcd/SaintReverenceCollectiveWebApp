using System;
using System.Collections.Generic;
using SaintReverenceMVC.Models.OrderModels;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IOrderService{
        Task<bool> CreateOrderAsync(OrderCreate model);
        Task<IEnumerable<OrderListItem>> GetAllOrdersAsync();
        Task<IEnumerable<OrderListItem>> GetAllOrdersAsync(Guid userID);
        OrderDetail GetOrderByID(Guid id);
        Task<IEnumerable<OrderListItem>> GetOrdersByStatusAsync(int orderStatus);
        Task<IEnumerable<OrderListItem>> GetUnfulfilledOrdersAsync();
        Task<IEnumerable<OrderListItem>> GetOrdersByDateAsync(DateTime orderDate);
        Task<bool> UpdateOrderAsync(OrderEdit model);
        Task<bool> DeleteOrderAsync(Guid id);
    }
}