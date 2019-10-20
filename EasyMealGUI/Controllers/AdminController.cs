using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;

namespace EasyMealManagementGUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IMealRepository repository;

        public AdminController(IMealRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Meals);

        public ViewResult Edit(int mealID) =>
            View(repository.Meals
                .FirstOrDefault(p => p.MealID == mealID));

        [HttpPost]
        public IActionResult Edit(Meal meal)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMeal(meal);
                TempData["message"] = $"{meal.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(meal);
            }
        }

        public ViewResult Create() => View("Edit", new Meal());

        [HttpPost]
        public IActionResult Delete(int mealID)
        {
            Meal deletedMeal = repository.DeleteMeal(mealID);
            if (deletedMeal != null)
            {
                TempData["message"] = $"{deletedMeal.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult SeedDatabase() {
        //    SeedData.EnsurePopulated(HttpContext.RequestServices);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
