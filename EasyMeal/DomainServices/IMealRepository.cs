using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasyMealCore.DomainModel;

namespace EasyMealCore.DomainServices
{
    public interface IMealRepository
    {
        IQueryable<Meal> Meals { get; }

        void SaveMeal(Meal meal);

        Meal DeleteMeal(int mealID);

        void DeleteAllMeals();
    }
}
