using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasyMealCore.DomainModel.Enums;
using System.Globalization;


namespace EasyMealCore.DomainModel.Validators
{
    public static class ValidateCart
    {
        private static Cart cart;
        public static bool Validate(this Cart _cart)
        {
            cart = _cart;
            if (ValidateCourses()) return true;
            return false;
        }

        public static bool ValidateCourses()
        {
            int starter = 0;
            int main = 0;
            int dessert = 0;
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek))) { 
                foreach (CartLine line in cart.Lines)
                {
                    if (line.Meal.Course == CourseTypes.Starter && ((int)day > 0 && (int)day < 6) && line.Meal.Day == day) starter++;
                    else if (line.Meal.Course == CourseTypes.Main && ((int)day > 0 && (int)day < 6) && line.Meal.Day == day) main++;
                    else if (line.Meal.Course == CourseTypes.Dessert && ((int)day > 0 && (int)day < 6) && line.Meal.Day == day) dessert++;
                }
            }
            if(starter+dessert<main || main<4)
            {
                return false;
            }
            return true;
        }
    }
}
