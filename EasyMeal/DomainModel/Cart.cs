using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMealCore.DomainModel
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Meal meal, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Meal.MealID == meal.MealID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
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

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public virtual Meal Meal { get; set; }
        public int Quantity { get; set; }
    }
}
