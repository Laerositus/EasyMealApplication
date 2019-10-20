using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainModel.Enums;

namespace EF_MSSQL_DataStore
{
    public class SeedData
    {

        public static void EnsurePopulated(ApplicationDbContext context)
        {
            //ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            ////context.Database.Migrate();
            if (!context.Meals.Any())
            {
                context.Meals.AddRange(
                    //Sunday
                    new Meal
                    {
                        Name = "SundayStarterAllFree",
                        Description = "SundayStarterAllFree",
                        Category = "Sunday",
                        Course = CourseTypes.Starter,
                        Price = 275,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Sunday,
                        Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png"
                    },
                    new Meal
                    {
                        Name = "SundayMainAllFree",
                        Description = "SundayMainAllFree",
                        Category = "Sunday",
                        Course = CourseTypes.Main, 
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Sunday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    }, 
                    new Meal
                    {
                        Name = "SundayDessertAllFree",
                        Description = "SundayDessertAllFree",
                        Category = "Sunday",
                        Course = CourseTypes.Dessert,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Sunday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    //Monday
                    new Meal
                    {
                        Name = "MondayStarterAllFree",
                        Description = "MondayStarterAllFree",
                        Category = "Monday",
                        Course = CourseTypes.Starter,
                        Price = 275,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Monday,
                        Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png"
                    },
                    new Meal
                    {
                        Name = "MondayMainAllFree",
                        Description = "MondayMainAllFree",
                        Category = "Monday",
                        Course = CourseTypes.Main,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Monday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    new Meal
                    {
                        Name = "MondayDessertAllFree",
                        Description = "MondayDessertAllFree",
                        Category = "Monday",
                        Course = CourseTypes.Dessert,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Monday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    //Tuesday
                    new Meal
                    {
                        Name = "TuesdayStarterAllFree",
                        Description = "TuesdayStarterAllFree",
                        Category = "Tuesday",
                        Course = CourseTypes.Starter,
                        Price = 275,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Tuesday,
                        Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png"
                    },
                    new Meal
                    {
                        Name = "TuesdayMainAllFree",
                        Description = "TuesdayMainAllFree",
                        Category = "Tuesday",
                        Course = CourseTypes.Main,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Tuesday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    new Meal
                    {
                        Name = "TuesdayDessertAllFree",
                        Description = "TuesdayDessertAllFree",
                        Category = "Tuesday",
                        Course = CourseTypes.Dessert,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Tuesday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    //Wednesday
                    new Meal
                    {
                        Name = "WednesdayStarterAllFree",
                        Description = "WednesdayStarterAllFree",
                        Category = "Wednesday",
                        Course = CourseTypes.Starter,
                        Price = 275,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Wednesday,
                        Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png"
                    },
                    new Meal
                    {
                        Name = "WednesdayMainAllFree",
                        Description = "WednesdayMainAllFree",
                        Category = "Wednesday",
                        Course = CourseTypes.Main,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Wednesday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    new Meal
                    {
                        Name = "WednesdayDessertAllFree",
                        Description = "WednesdayDessertAllFree",
                        Category = "Wednesday",
                        Course = CourseTypes.Dessert,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Wednesday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    //Thursday
                    new Meal
                    {
                        Name = "ThursdayStarterAllFree",
                        Description = "ThursdayStarterAllFree",
                        Category = "Thursday",
                        Course = CourseTypes.Starter,
                        Price = 275,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Thursday,
                        Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png"
                    },
                    new Meal
                    {
                        Name = "ThursdayMainAllFree",
                        Description = "ThursdayMainAllFree",
                        Category = "Thursday",
                        Course = CourseTypes.Main,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Thursday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    new Meal
                    {
                        Name = "ThursdayDessertAllFree",
                        Description = "ThursdayDessertAllFree",
                        Category = "Thursday",
                        Course = CourseTypes.Dessert,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Thursday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    //Friday
                    new Meal
                    {
                        Name = "FridayStarterAllFree",
                        Description = "FridayStarterAllFree",
                        Category = "Friday",
                        Course = CourseTypes.Starter,
                        Price = 275,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Friday,
                        Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png"
                    },
                    new Meal
                    {
                        Name = "FridayMainAllFree",
                        Description = "FridayMainAllFree",
                        Category = "Friday",
                        Course = CourseTypes.Main,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Friday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    new Meal
                    {
                        Name = "FridayDessertAllFree",
                        Description = "FridayDessertAllFree",
                        Category = "Friday",
                        Course = CourseTypes.Dessert,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Friday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    //Saturday
                    new Meal
                    {
                        Name = "SaturdayStarterAllFree",
                        Description = "SaturdayStarterAllFree",
                        Category = "Saturday",
                        Course = CourseTypes.Starter,
                        Price = 275,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Saturday,
                        Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png"
                    },
                    new Meal
                    {
                        Name = "SaturdayMainAllFree",
                        Description = "SaturdayMainAllFree",
                        Category = "Saturday",
                        Course = CourseTypes.Main,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Saturday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    },
                    new Meal
                    {
                        Name = "SaturdayDessertAllFree",
                        Description = "SaturdayDessertAllFree",
                        Category = "Saturday",
                        Course = CourseTypes.Dessert,
                        Price = 300,
                        SaltFree = true,
                        SugarFree = true,
                        GlutenFree = true,
                        Day = DayOfWeek.Saturday,
                        Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
