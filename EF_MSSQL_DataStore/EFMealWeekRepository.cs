using System.Collections.Generic;
using System.Linq;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;

namespace EF_MSSQL_DataStore
{
    public class EFMealWeekRepository : IMealWeekRepository
    {
        private ApplicationDbContext context;

        public EFMealWeekRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<MealWeek> MealWeeks => context.MealWeeks;

        public void SaveMealWeek(MealWeek mealWeek)
        {
            context.AttachRange(mealWeek.Lines.Select(l => l.Meal));
            if (mealWeek.MealWeekID == 0)
            {
                context.MealWeeks.Add(mealWeek);
            }
            context.SaveChanges();
        }
    }
}
