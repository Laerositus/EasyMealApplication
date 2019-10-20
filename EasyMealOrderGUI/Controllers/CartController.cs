using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EasyMealOrderGUI.Models.ViewModels;


using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;
using EasyMealOrderGUI.Http;
using EF_MSSQL_DataStore;
using EasyMealCore.DomainModel.Validators;

namespace EasyMealOrderGUI.Controllers
{
    public class CartController : Controller
    {
        private IQueryable<Meal> repository;
        private Cart cart;

        public CartController(IMealRepository repo, Cart cartService, ApplicationDbContext ctx)
        {
            if (repo!=null)
            {
                repository = repo.Meals;
            }
            else repository = new MealListGetter(repo, ctx).GetAllMeals().AsQueryable();
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int mealID, string returnUrl)
        {
            Meal meal = repository
                .FirstOrDefault(p => p.MealID == mealID);
            if (meal != null)
            {
                cart.AddItem(meal, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int mealID,
                string returnUrl)
        {
            Meal meal = repository
                .FirstOrDefault(p => p.MealID == mealID);

            if (meal != null)
            {
                cart.RemoveLine(meal);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult Validate(string returnUrl)
        {
            if (!(cart.Validate()))
            {
                TempData["message"] = "Not all meals fullfill the conditions";
            }
            else
            {
                return RedirectToAction("Checkout", "Order", new { returnUrl });
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
