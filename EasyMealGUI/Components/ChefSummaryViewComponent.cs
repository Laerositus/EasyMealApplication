using Microsoft.AspNetCore.Mvc;

using EasyMealCore.DomainModel;

namespace EasyMealManagementGUI.Components
{
    public class InputMealsSummaryViewComponent : ViewComponent
    {
        private InputMeals InputMeals;

        public InputMealsSummaryViewComponent(InputMeals InputMealsService)
        {
            InputMeals = InputMealsService;
        }

        public IViewComponentResult Invoke()
        {
            return View(InputMeals);
        }
    }
}
