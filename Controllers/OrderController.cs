using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Controllers{
    public class OrderController : Controller{
        public IActionResult Index(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            var svc = new OrderService(userID);
            var model = svc.GetAllOrders();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public IActionResult Create(OrderCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = CreateOrderService();
            if(svc.CreateOrder(model)){
                TempData["SaveResult"] = "Order has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("OrderCreateFailed", "Something went wrong while attempting to create the Order, please try again");
            return View(model);
        }

        public IActionResult Details(Guid id){
            var svc = CreateOrderService();
            var model = svc.GetOrderByID(id);
            return View(model);
        }

        public IActionResult IndexByOrderStatus(int orderStatus){
            var svc = CreateOrderService();
            var model = svc.GetOrdersByStatus(orderStatus);
            return View(model);
        }

        public IActionResult IndexByOrderDate(DateTime orderDate){
            var svc = CreateOrderService();
            var model = svc.GetOrdersByDate(orderDate);
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(Guid id){
            var svc = CreateOrderService();
            var detail = svc.GetOrderByID(id);
            var model = new OrderEdit{
                OrderID = detail.OrderID,
                OrderStatus = detail.OrderStatus,
                ShippedDate = detail.ShippedDate
            };
            return View(model);
        }

        // POST: Edit
        public IActionResult Edit(Guid id, OrderEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.OrderID != id){
                ModelState.AddModelError("OrderIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = CreateOrderService();
            if (svc.UpdateOrder(model)){
                TempData["SaveResult"] = "Order information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("OrderEditFailed", "Something went wrong while attempting to update the Order information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(Guid id){
            var svc = CreateOrderService();
            var model = svc.GetOrderByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public IActionResult DeleteOrder(Guid id){
            var svc = CreateOrderService();
            svc.DeleteOrder(id);
            TempData["SaveResult"] = "Order has been successfully deleted!";
            return Redirect(nameof(Index));
        }

        private OrderService CreateOrderService(){
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var userID = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            return new OrderService(userID);
        }
    }
}