using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;
using EF_MSSQL_DataStore;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace EasyMealOrderGUI.Http
{
    public class MealListGetter
    {
        private string apiUrl = "http://localhost:5000/api/v1/";
        private IEnumerable<Meal> meals = null;
        private IMealRepository repository;
        private ApplicationDbContext context;

        public MealListGetter(IMealRepository repo, ApplicationDbContext ctx)
        {
            context = ctx;
            repository = repo;
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetAsync("meals");
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<IList<Meal>>();
                    readTask.Wait();

                    meals = readTask.Result;
                    return meals;

                }
                else
                {
                    meals = Enumerable.Empty<Meal>();
                    return meals;
                }

            }
        }
    }
}
