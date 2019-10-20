using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;

namespace EasyMealManagementGUI.Controllers
{
    [Authorize]
    public class MealWeekController : Controller
    {
        private IMealWeekRepository repository;
        private InputMeals InputMeals;

        public MealWeekController(IMealWeekRepository repoService, InputMeals InputMealsService)
        {
            repository = repoService;
            InputMeals = InputMealsService;
        }

        public ViewResult List() =>
            View(repository.MealWeeks.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int mealWeekID)
        {
            MealWeek mealWeek = repository.MealWeeks
                .FirstOrDefault(o => o.MealWeekID == mealWeekID);
            if (mealWeek != null)
            {
                mealWeek.Shipped = true;
                repository.SaveMealWeek(mealWeek);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new MealWeek());

        [HttpPost]
        public IActionResult Checkout(MealWeek mealWeek)
        {
            if (InputMeals.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your InputMeals is empty!");
            }
            if (ModelState.IsValid)
            {
                mealWeek.Lines = InputMeals.Lines.ToArray();
                repository.SaveMealWeek(mealWeek);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(mealWeek);
            }
        }

        public ViewResult Completed()
        {
            InputMeals.Clear();
            return View();
        }
    }
}
