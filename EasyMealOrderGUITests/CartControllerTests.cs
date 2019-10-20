using EasyMealCore.DomainModel;
using EasyMealCore.DomainModel.Enums;
using EasyMealCore.DomainModel.Validators;
using EasyMealCore.DomainServices;
using EasyMealOrderGUI.Models;
using EasyMealOrderGUI.Controllers;

using Moq;
using System;
using System.Linq;
using Xunit;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;

namespace EasyMealOrderGUITests
{
    public class CartControllerTests
    {
        [Fact]
        public void MinimalDaysTest()
        {
            //Arrange

            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            mock.Setup(m => m.Meals).Returns(new Meal[]
            {
                //Sunday
                new Meal { MealID = 1, Name = "Day0StarterSugarFree", Description ="Day0StarterSugarFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Sunday, Image = ""},
                new Meal { MealID = 2, Name = "Day0MainGlutenFree", Description = "Day0MainGlutenFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Sunday, Image = ""},
                new Meal { MealID = 3, Name = "Day0DessertSaltFree", Description = "Day0DessertSaltFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Sunday, Image = ""},
                //Monday          
                new Meal { MealID = 4, Name = "Day1StarterSugarFree", Description = "Day1StarterSugarFree", Category = "Potato", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Monday, Image = ""},
                new Meal { MealID = 5, Name = "Day1MainGlutenFree", Description = "Day1MainGlutenFree",Category = "Potato", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Monday, Image = ""},
                new Meal { MealID = 6, Name = "Day1DessertSaltFree", Description = "Day1DessertSaltFree",Category = "Potato", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Monday, Image = ""},
                //Tuesday        
                new Meal { MealID = 7, Name = "Day2StarterSugarFree", Description = "Day2StarterSugarFree",Category = "Salad", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Tuesday, Image = ""},
                new Meal { MealID = 8, Name = "Day2MainGlutenFree", Description = "Day2MainGlutenFree",Category = "Salad", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Tuesday, Image = ""},
                new Meal { MealID = 9, Name = "Day2DessertSaltFree", Description = "Day2DessertSaltFree",Category = "Salad", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Tuesday, Image = ""},
                //Wednesday    
                new Meal { MealID = 10, Name = "Day3StarterSugarFree", Description = "Day3StarterSugarFree", Category = "Mexican", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Wednesday, Image = ""},
                new Meal { MealID = 11, Name = "Day3MainGlutenFree", Description = "Day3MainGlutenFree", Category = "Mexican", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Wednesday, Image = ""},
                new Meal { MealID = 12, Name = "Day3DessertSaltFree", Description = "Day3DessertSaltFree", Category = "Mexican", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Wednesday, Image = ""},
                //Thursday      
                new Meal { MealID = 13, Name = "Day4StarterSugarFree", Description = "Day4StarterSugarFree", Category = "Vegan", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Thursday, Image = ""},
                new Meal { MealID = 14, Name = "Day4MainGlutenFree", Description =  "Day4MainGlutenFree", Category = "Vegan", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Thursday, Image = ""},
                new Meal { MealID = 15, Name = "Day4DessertSaltFree", Description = "Day4DessertSaltFree", Category = "Vegan", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Thursday, Image = ""},
                //Friday         
                new Meal { MealID = 16, Name = "Day5MainGlutenFree", Description = "Day5MainGlutenFree", Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Friday, Image = ""},
                new Meal { MealID = 17, Name = "Day5StarterSugarFree", Description = "Day5StarterSugarFree", Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Friday, Image = ""},
                new Meal { MealID = 18, Name = "Day5DessertSaltFree", Description = "Day5DessertSaltFree", Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Friday, Image = ""},
                //Sunday        
                new Meal { MealID = 19, Name = "SundayStarterAllFree", Description = "SundayStarterAllFree", Category = "Sunday", Course = CourseTypes.Starter, Price = 275, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Sunday, Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png" },
                new Meal { MealID = 20, Name = "SundayMainAllFree", Description = "SundayMainAllFree", Category = "Sunday", Course = CourseTypes.Main, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Sunday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                new Meal { MealID = 21, Name = "SundayDessertAllFree", Description = "SundayDessertAllFree", Category = "Sunday", Course = CourseTypes.Dessert, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Sunday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                //Monday         
                new Meal { MealID = 22, Name = "MondayStarterAllFree", Description = "MondayStarterAllFree", Category = "Monday", Course = CourseTypes.Starter, Price = 275, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Monday, Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png" },
                new Meal { MealID = 23, Name = "MondayMainAllFree", Description = "MondayMainAllFree", Category = "Monday", Course = CourseTypes.Main, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Monday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                new Meal { MealID = 24, Name = "MondayDessertAllFree", Description = "MondayDessertAllFree", Category = "Monday", Course = CourseTypes.Dessert, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Monday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                //Tuesday       
                new Meal { MealID = 25, Name = "TuesdayStarterAllFree", Description = "TuesdayStarterAllFree", Category = "Tuesday", Course = CourseTypes.Starter, Price = 275, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Tuesday, Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png" },
                new Meal { MealID = 26, Name = "TuesdayMainAllFree", Description = "TuesdayMainAllFree", Category = "Tuesday", Course = CourseTypes.Main, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Tuesday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                new Meal { MealID = 27, Name = "TuesdayDessertAllFree", Description = "TuesdayDessertAllFree", Category = "Tuesday", Course = CourseTypes.Dessert, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Tuesday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                //Wednesday       
                new Meal { MealID = 28, Name = "WednesdayStarterAllFree", Description = "WednesdayStarterAllFree", Category = "Wednesday", Course = CourseTypes.Starter, Price = 275, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Wednesday, Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png" },
                new Meal { MealID = 29, Name = "WednesdayMainAllFree", Description = "WednesdayMainAllFree", Category = "Wednesday", Course = CourseTypes.Main, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Wednesday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                new Meal { MealID = 30, Name = "WednesdayDessertAllFree", Description = "WednesdayDessertAllFree", Category = "Wednesday", Course = CourseTypes.Dessert, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Wednesday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                //Thursday      
                new Meal { MealID = 31, Name = "ThursdayStarterAllFree", Description = "ThursdayStarterAllFree", Category = "Thursday", Course = CourseTypes.Starter, Price = 275, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Thursday, Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png" },
                new Meal { MealID = 32, Name = "ThursdayMainAllFree", Description = "ThursdayMainAllFree", Category = "Thursday", Course = CourseTypes.Main, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Thursday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                new Meal { MealID = 33, Name = "ThursdayDessertAllFree", Description = "ThursdayDessertAllFree", Category = "Thursday", Course = CourseTypes.Dessert, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Thursday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                //Friday        
                new Meal { MealID = 34, Name = "FridayStarterAllFree", Description = "FridayStarterAllFree", Category = "Friday", Course = CourseTypes.Starter, Price = 275, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Friday, Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png" },
                new Meal { MealID = 35, Name = "FridayMainAllFree", Description = "FridayMainAllFree", Category = "Friday", Course = CourseTypes.Main, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Friday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                new Meal { MealID = 36, Name = "FridayDessertAllFree", Description = "FridayDessertAllFree", Category = "Friday", Course = CourseTypes.Dessert, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Friday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                //Saturday      
                new Meal { MealID = 37, Name = "SaturdayStarterAllFree", Description = "SaturdayStarterAllFree", Category = "Saturday", Course = CourseTypes.Starter, Price = 275, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Saturday, Image = "https://upload.wikimedia.org/wikipedia/en/4/4d/Shrek_%28character%29.png" },
                new Meal { MealID = 38, Name = "SaturdayMainAllFree", Description = "SaturdayMainAllFree", Category = "Saturday", Course = CourseTypes.Main, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Saturday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" },
                new Meal { MealID = 39, Name = "SaturdayDessertAllFree", Description = "SaturdayDessertAllFree", Category = "Saturday", Course = CourseTypes.Dessert, Price = 300, SaltFree = true, SugarFree = true, GlutenFree = true, Day = DayOfWeek.Saturday, Image = "https://i.kym-cdn.com/entries/icons/facebook/000/020/110/Dfdddddd.jpg" }
            }.AsQueryable<Meal>());

            //Assert

            Cart cart = new Cart();

            foreach (Meal meal in mock.Object.Meals)
            {
                cart.AddItem(meal, 1);
            }

            CartController target = new CartController(mock.Object, cart, null);
            IActionResult result = target.Validate(string.Empty);
            Assert.Equal("Checkout", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void MinimalDaysTestFail()
        {
            //Arrange
            var tempDataProvider = new Mock<SessionStateTempDataProvider>();


            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            mock.Setup(m => m.Meals).Returns(new Meal[]
            {
                //Sunday
                new Meal { MealID = 1, Name = "Day0StarterSugarFree", Description ="Day0StarterSugarFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Sunday, Image = ""},
                new Meal { MealID = 2, Name = "Day0MainGlutenFree", Description = "Day0MainGlutenFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Sunday, Image = ""},
                new Meal { MealID = 3, Name = "Day0DessertSaltFree", Description = "Day0DessertSaltFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Sunday, Image = ""},
                //Monday          
                new Meal { MealID = 4, Name = "Day1StarterSugarFree", Description = "Day1StarterSugarFree", Category = "Potato", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Monday, Image = ""},
                new Meal { MealID = 5, Name = "Day1MainGlutenFree", Description = "Day1MainGlutenFree",Category = "Potato", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Monday, Image = ""},
                new Meal { MealID = 6, Name = "Day1DessertSaltFree", Description = "Day1DessertSaltFree",Category = "Potato", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Monday, Image = ""},
                //Tuesday        
                new Meal { MealID = 7, Name = "Day2StarterSugarFree", Description = "Day2StarterSugarFree",Category = "Salad", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Tuesday, Image = ""},
                new Meal { MealID = 8, Name = "Day2MainGlutenFree", Description = "Day2MainGlutenFree",Category = "Salad", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Tuesday, Image = ""},
                new Meal { MealID = 9, Name = "Day2DessertSaltFree", Description = "Day2DessertSaltFree",Category = "Salad", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Tuesday, Image = ""}
            }.AsQueryable<Meal>());

            Cart cart = new Cart();

            foreach (Meal meal in mock.Object.Meals)
            {
                cart.AddItem(meal, 1);
            }


            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            CartController target = new CartController(mock.Object, cart, null)
            {
                TempData = tempData
            };


            //Act
            IActionResult result = target.Validate(string.Empty);

            //Assert
            Assert.NotEqual("Checkout", (result as RedirectToActionResult).ActionName);
        }
    }
}