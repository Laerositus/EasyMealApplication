using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EasyMealOrderGUI.Models.ViewModels;
using EasyMealOrderGUI.Http;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;
using EF_MSSQL_DataStore;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Authorization;

namespace EasyMealOrderGUI.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        private IQueryable<Meal> repository;
        public int PageSize = 999;

        public MealController(IMealRepository repo, ApplicationDbContext ctx)
        {
            repository = new MealListGetter(repo, ctx).GetAllMeals().AsQueryable();
        }

        public ViewResult List(string category, int productPage = 1)
            => View(new MealsListViewModel
            {
                Meals = repository
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.MealID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Count() :
                        repository.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
