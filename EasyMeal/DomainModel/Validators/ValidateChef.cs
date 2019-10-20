using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasyMealCore.DomainModel;
using EasyMealCore.DomainModel.Enums;

namespace EasyMealCore.DomainModel.Validators
{
    public static class ValidateInputMeals
    {
        private static InputMeals InputMeals;

        public static bool Validate(this InputMeals _InputMeals)
        {
            InputMeals = _InputMeals;
            if (!validateAmount()) return false;
            if (!ValidateAllergies()) return false;
            return true;
        }
        private static bool validateAmount()
        {
            //InputMeals.Lines.Count();
            //if (InputMeals.Lines.Count() >= 21)
            //{
            //    return true;
            //}
            //else return false;
            int validDays = 0;
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                bool starter = false;
                bool main = false;
                bool dessert = false;
                foreach (InputMealsLine line in InputMeals.Lines.Where(n => n.Meal.Day == day))
                {
                    if (line.Meal.Course == CourseTypes.Starter) starter = true;
                    if (line.Meal.Course == CourseTypes.Main) main = true;
                    if (line.Meal.Course == CourseTypes.Dessert) dessert = true;
                }
                if (starter && main && dessert)
                {
                    validDays++;
                }
            }
            if (validDays == 7)
            {
                return true;
            }
            return false;
        }

            private static bool validateContainsAllergy()
        {
            bool allAvailable = false;
            List<Meal> allMeals = new List<Meal>();
            foreach (InputMealsLine line in InputMeals.Lines)
            {
                allMeals.Add(line.Meal);
            }

            for(int i = 0; i < 8; i++)
            {
                List<Meal> meals = new List<Meal>();

                foreach (Meal m in allMeals)
                {
                    if (m.Day.Equals(i))
                    {
                        meals.Add(m);
                    }
                }

                string[] courseArray = Enum.GetNames(typeof(CourseTypes));
                string[] allergyArray = Enum.GetNames(typeof(AllergyTypes));

                foreach (Meal m in meals)
                {

                    foreach (var c in courseArray)
                    {
                        if (m.Course.Equals(c))
                        {
                            foreach (var a in allergyArray)
                            {
                              
                                switch (a)
                                {
                                    case "Salt":
                                        if (m.SaltFree)
                                        {
                                            allAvailable = true;
                                        }
                                        else allAvailable = false;
                                        break;
                                    case "Diabetes":
                                        if (m.SugarFree)
                                        {
                                            allAvailable = true;
                                        }
                                        else allAvailable = false;
                                        break;
                                    case "Gluten":
                                        if (m.GlutenFree)
                                        {
                                            allAvailable = true;
                                        }
                                        else allAvailable = false;
                                        break;
                                }
                            }
                        }                        
                    }                    
                }                
            }
            return allAvailable;
        }

        private static bool ValidateAllergies()
        {
            int validDays = 0;
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                bool starter = false;
                bool main = false;
                bool dessert = false;
                foreach (CourseTypes courseType in Enum.GetValues(typeof(CourseTypes)))
                {
                    bool glutenFree = false;
                    bool sugarFree = false;
                    bool saltFree = false;
                    foreach (InputMealsLine line in InputMeals.Lines.Where(n => n.Meal.Day == day && n.Meal.Course == courseType))
                    {
                        if (line.Meal.GlutenFree) glutenFree = true;
                        if (line.Meal.SugarFree) sugarFree = true;
                        if (line.Meal.SaltFree) saltFree = true;
                    }
                    if (glutenFree && sugarFree && saltFree)
                    {
                        if (courseType == CourseTypes.Starter) starter = true;
                        if (courseType == CourseTypes.Main) main = true;
                        if (courseType == CourseTypes.Dessert) dessert = true;
                    }
                }
                if (starter && main && dessert)
                {
                    validDays++;
                }
            }
            if (validDays == 7) return true;
            return false;
        }
    }
}
