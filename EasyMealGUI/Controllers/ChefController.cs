using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EasyMealManagementGUI.Models.ViewModels;


using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;
using EasyMealCore.DomainModel.Validators;
using Microsoft.AspNetCore.Authorization;

namespace EasyMealManagementGUI.Controllers
{
    [Authorize]
    public class InputMealsController : Controller
    {
        private IMealRepository repository;
        private InputMeals InputMeals;

        public InputMealsController(IMealRepository repo, InputMeals InputMealsService)
        {
            repository = repo;
            InputMeals = InputMealsService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new InputMealsIndexViewModel
            {
                InputMeals = InputMeals,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToInputMeals(int mealID, string returnUrl)
        {
            Meal meal = repository.Meals
                .FirstOrDefault(p => p.MealID == mealID);
            if (meal != null)
            {
                InputMeals.AddItem(meal, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromInputMeals(int mealID,
                string returnUrl)
        {
            Meal meal = repository.Meals
                .FirstOrDefault(p => p.MealID == mealID);

            if (meal != null)
            {
                InputMeals.RemoveLine(meal);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult Validate(string returnUrl)
        {
            if (!(InputMeals.Validate()))
            {
                TempData["message"] = "The mealweek does not fullfill all conditions";
            }
            else
            {
                return RedirectToAction("Checkout", "MealWeek");
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
