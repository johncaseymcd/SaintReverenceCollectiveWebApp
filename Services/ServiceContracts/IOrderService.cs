using System;
using System.Collections.Generic;
using SaintReverenceMVC.Models.OrderModels;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface IOrderService{
        bool CreateOrder(OrderCreate model);
        IEnumerable<OrderListItem> GetAllOrders();
        IEnumerable<OrderListItem> GetAllOrders(Guid userID);
        OrderDetail GetOrderByID(Guid id);
        IEnumerable<OrderListItem> GetOrdersByStatus(int orderStatus);
        IEnumerable<OrderListItem> GetOrdersByDate(DateTime orderDate);
        bool UpdateOrder(OrderEdit model);
        bool DeleteOrder(Guid id);
    }
}