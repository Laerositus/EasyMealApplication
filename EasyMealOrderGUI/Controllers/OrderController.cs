using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;
using EF_MSSQL_DataStore;

namespace EasyMealOrderGUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private IMealRepository mealRepository;
        private Cart cart;
        private ApplicationDbContext context;

        public OrderController(IOrderRepository repoService, Cart cartService, ApplicationDbContext ctx, IMealRepository repo)
        {
            repository = repoService;
            cart = cartService;
            mealRepository = repo;
            context = ctx;
        }

        [Authorize]
        public ViewResult List() =>
            View(repository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int OrderID)
        {
            Order Order = repository.Orders
                .FirstOrDefault(o => o.OrderID == OrderID);
            if (Order != null)
            {
                Order.Shipped = true;
                repository.SaveOrder(Order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order Order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                Order.UserName = User.Identity.Name;
                Order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(Order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(Order);
            }
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
