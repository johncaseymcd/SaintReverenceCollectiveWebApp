using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SaintReverenceMVC.Models.OrderModels;
using SaintReverenceMVC.Services;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Controllers{
    public class OrderController : Controller{
        public async Task<IActionResult> Index(){
            var svc = new OrderService();
            var model = await svc.GetAllOrdersAsync();
            return View(model);
        }

        // GET: Create
        public IActionResult Create(){
            return View();
        }

        // POST: Create
        public async Task<IActionResult> Create(OrderCreate model){
            if (!ModelState.IsValid) return View(model);

            var svc = new OrderService();
            if(await svc.CreateOrderAsync(model)){
                TempData["SaveResult"] = "Order has been successfully created!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("OrderCreateFailed", "Something went wrong while attempting to create the Order, please try again");
            return View(model);
        }

        public IActionResult Details(Guid id){
            var svc = new OrderService();
            var model = svc.GetOrderByID(id);
            return View(model);
        }

        public async Task<IActionResult> IndexByOrderStatus(int orderStatus){
            var svc = new OrderService();
            var model = await svc.GetOrdersByStatusAsync(orderStatus);
            return View(model);
        }

        public async Task<IActionResult> IndexByOrderDate(DateTime orderDate){
            var svc = new OrderService();
            var model = await svc.GetOrdersByDateAsync(orderDate);
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(Guid id){
            var svc = new OrderService();
            var detail = svc.GetOrderByID(id);
            var model = new OrderEdit{
                OrderID = detail.OrderID,
                OrderStatus = detail.OrderStatus,
                ShippedDate = detail.ShippedDate
            };
            return View(model);
        }

        // POST: Edit
        public async Task<IActionResult> Edit(Guid id, OrderEdit model){
            if (!ModelState.IsValid) return View(model);
            if (model.OrderID != id){
                ModelState.AddModelError("OrderIdMismatch", "Given ID parameter does not match existing database ID, please try again.");
                return View(model);
            }

            var svc = new OrderService();
            if (await svc.UpdateOrderAsync(model)){
                TempData["SaveResult"] = "Order information has been successfully updated!";
                return Redirect(nameof(Index));
            }

            ModelState.AddModelError("OrderEditFailed", "Something went wrong while attempting to update the Order information, please try again.");
            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public IActionResult Delete(Guid id){
            var svc = new OrderService();
            var model = svc.GetOrderByID(id);
            return View(model);
        }

        // POST: Delete
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteOrder(Guid id){
            var svc = new OrderService();
            await svc.DeleteOrderAsync(id);
            TempData["SaveResult"] = "Order has been successfully deleted!";
            return Redirect(nameof(Index));
        }
    }
}