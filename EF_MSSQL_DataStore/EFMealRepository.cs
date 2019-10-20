using System;
using System.Collections.Generic;
using System.Linq;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace EF_MSSQL_DataStore
{
    public class EFMealRepository : IMealRepository
    {
        private ApplicationDbContext context;

        public EFMealRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Meal> Meals => context.Meals;

        public void SaveMeal(Meal meal)
        {
            var meals = context.Meals;
                Meal dbEntry = context.Meals
                    .FirstOrDefault(p => p.MealID == meal.MealID);
                if (dbEntry != null)
                {
                    dbEntry.Name = meal.Name;
                    dbEntry.Description = meal.Description;
                    dbEntry.Price = meal.Price;
                    dbEntry.Category = meal.Category;
                    dbEntry.Course = meal.Course;
                    dbEntry.SugarFree = meal.SugarFree;
                    dbEntry.GlutenFree = meal.GlutenFree;
                    dbEntry.SaltFree = meal.SaltFree;
                    dbEntry.Day = meal.Day;
                    dbEntry.Image = meal.Image;
                }
                else
                {
                    meal.MealID = 0;
                    context.Meals.Add(meal);
                }
            context.SaveChanges();
        }

        public Meal DeleteMeal(int mealID)
        {
            Meal dbEntry = context.Meals
                .FirstOrDefault(p => p.MealID == mealID);
            if (dbEntry != null)
            {
                context.Meals.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void DeleteAllMeals()
        {
            context.Meals.RemoveRange(context.Meals);
            context.SaveChanges();
        }
    }
}
