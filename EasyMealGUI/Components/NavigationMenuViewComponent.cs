using Microsoft.AspNetCore.Mvc;
using System.Linq;

using EasyMealCore.DomainServices;

namespace EasyMealManagementGUI.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IMealRepository repository;

        public NavigationMenuViewComponent(IMealRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Meals
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
