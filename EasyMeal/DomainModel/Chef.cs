using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMealCore.DomainModel
{
    public class InputMeals
    {
        private List<InputMealsLine> lineCollection = new List<InputMealsLine>();

        public virtual void AddItem(Meal meal, int quantity)
        {
            InputMealsLine line = lineCollection
                .Where(p => p.Meal.MealID == meal.MealID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new InputMealsLine
                {
                    Meal = meal,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Meal meal) =>
            lineCollection.RemoveAll(l => l.Meal.MealID == meal.MealID);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Meal.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<InputMealsLine> Lines => lineCollection;
    }

    public class InputMealsLine
    {
        public int InputMealsLineID { get; set; }
        public virtual Meal Meal { get; set; }
        public int Quantity { get; set; }
    }
}
