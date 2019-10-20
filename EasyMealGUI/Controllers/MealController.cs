using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EasyMealManagementGUI.Models.ViewModels;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;
using Microsoft.AspNetCore.Authorization;

namespace EasyMealManagementGUI.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        private IMealRepository repository;
        public int PageSize = 999;

        public MealController(IMealRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1)
            => View(new MealsListViewModel
            {
                Meals = repository.Meals
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.MealID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Meals.Count() :
                        repository.Meals.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
