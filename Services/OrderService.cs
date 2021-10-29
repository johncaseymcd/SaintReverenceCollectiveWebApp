using System;
using System.Linq;
using System.Collections.Generic;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Services.ServiceContracts;

namespace SaintReverenceMVC.Services{
    public class OrderService : IOrderService{
        public bool CreateOrder(OrderCreate model){
            var entity = new Order{
                OrderDate = model.OrderDate,
                OrderStatus = model.OrderStatus,
                OrderTotal = model.OrderTotal,
                CustomerID = model.CustomerID,
                PackageID = model.PackageID, 
                Products = model.Products
            };

            using (var ctx = new src_backendContext()){
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetAllOrders(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    });

                return query.ToList().OrderBy(o => o.CustomerID).ThenBy(o => o.OrderStatus).ThenBy(o => o.OrderDate);
            }
        }

        public IEnumerable<OrderListItem> GetAllOrders(Guid userID){
            if (_userID == userID){
                using (var ctx = new src_backendContext()){
                    var query = ctx.Orders
                        .Where(o => o.CustomerID == _userID)
                        .Select(oli => new OrderListItem{
                            OrderID = oli.OrderID,
                            OrderDate = oli.OrderDate,
                            OrderStatus = oli.OrderStatus,
                            OrderTotal = oli.OrderTotal,
                            CustomerID = oli.CustomerID
                        });

                    return query.ToList().OrderBy(o => o.OrderDate).ThenBy(o => o.OrderStatus);
                }
            }
            return null;
        }

        public OrderDetail GetOrderByID(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Orders.Find(id);

                return new OrderDetail{
                    OrderID = entity.OrderID,
                    OrderDate = entity.OrderDate,
                    ShippedDate = entity.ShippedDate,
                    OrderTotal = entity.OrderTotal,
                    OrderStatus = entity.OrderStatus,
                    CustomerID = entity.CustomerID,
                    PackageID = entity.PackageID
                };
            }
        }

        public IEnumerable<OrderListItem> GetOrdersByStatus(int orderStatus){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Where(o => o.OrderStatus == orderStatus)
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    });

                return query.ToList().OrderBy(o => o.CustomerID).ThenBy(o => o.OrderDate);
            }
        }

        public IEnumerable<OrderListItem> GetOrdersByDate(DateTime orderDate){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Where(o => o.OrderDate == orderDate)
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    });

                return query.ToList().OrderBy(o => o.OrderStatus).ThenBy(o => o.CustomerID);
            }
        }

        public bool UpdateOrder(OrderEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Orders.Find(model.OrderID);

                entity.OrderStatus = model.OrderStatus;
                entity.ShippedDate = model.ShippedDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOrder(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Orders.Find(id);
                ctx.Orders.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}