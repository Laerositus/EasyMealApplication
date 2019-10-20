using Microsoft.AspNetCore.Mvc;
using System.Linq;

using EasyMealCore.DomainServices;
using EasyMealCore.DomainModel;
using EasyMealOrderGUI.Http;
using EF_MSSQL_DataStore;

namespace EasyMealOrderGUI.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IQueryable<Meal> repository;

        public NavigationMenuViewComponent(IMealRepository repo, ApplicationDbContext ctx)
        {
            repository = new MealListGetter(repo, ctx).GetAllMeals().AsQueryable();
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
