using System;
using System.Linq;
using System.Collections.Generic;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Services.ServiceContracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaintReverenceMVC.Services{
    public class OrderService : IOrderService{
        public async Task<bool> CreateOrderAsync(OrderCreate model){
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
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<OrderListItem>> GetAllOrdersAsync(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    })
                    .OrderBy(o => o.CustomerID).ThenBy(o => o.OrderStatus).ThenBy(o => o.OrderDate);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<OrderListItem>> GetAllOrdersAsync(Guid userID){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Where(o => o.CustomerID == userID)
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    })
                    .OrderBy(o => o.OrderDate).ThenBy(o => o.OrderStatus);

                return await query.ToListAsync();
            }
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

        public async Task<IEnumerable<OrderListItem>> GetOrdersByStatusAsync(int orderStatus){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Where(o => o.OrderStatus == orderStatus)
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    })
                    .OrderBy(o => o.CustomerID).ThenBy(o => o.OrderDate);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<OrderListItem>> GetUnfulfilledOrdersAsync(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Where(o => o.OrderStatus == 1 || o.OrderStatus == 2 || o.OrderStatus == 3)
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    })
                    .OrderBy(o => o.OrderStatus).ThenBy(o => o.OrderDate);

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<OrderListItem>> GetOrdersByDateAsync(DateTime orderDate){
            using (var ctx = new src_backendContext()){
                var query = ctx.Orders
                    .Where(o => o.OrderDate == orderDate)
                    .Select(oli => new OrderListItem{
                        OrderID = oli.OrderID,
                        OrderDate = oli.OrderDate,
                        OrderStatus = oli.OrderStatus,
                        OrderTotal = oli.OrderTotal,
                        CustomerID = oli.CustomerID
                    })
                    .OrderBy(o => o.OrderStatus).ThenBy(o => o.CustomerID);

                return await query.ToListAsync();
            }
        }

        public async Task<bool> UpdateOrderAsync(OrderEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Orders.Find(model.OrderID);

                entity.OrderStatus = model.OrderStatus;
                entity.ShippedDate = model.ShippedDate;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteOrderAsync(Guid id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Orders.Find(id);
                ctx.Orders.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}