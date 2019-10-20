using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasyMealCore.DomainModel;

namespace EasyMealCore.DomainServices
{
    public interface IMealWeekRepository 
    {
        IQueryable<MealWeek> MealWeeks { get; }
        void SaveMealWeek(MealWeek mealWeek);
    }
}
