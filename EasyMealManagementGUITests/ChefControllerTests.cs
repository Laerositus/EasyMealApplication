using EasyMealCore.DomainModel;
using EasyMealCore.DomainModel.Enums;
using EasyMealCore.DomainModel.Validators;
using EasyMealCore.DomainServices;
using EasyMealManagementGUI.Models;
using EasyMealManagementGUI.Controllers;

using Moq;
using System;
using System.Linq;
using Xunit;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;


namespace EasyMealManagementGUITests
{
    public class InputMealsControllerTests
    {
        [Fact]
        public void ValidateEnoughMealsForEveryDayFail()
        {
            //Arrange

            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            mock.Setup(m => m.Meals).Returns(new Meal[]
            {
                new Meal { MealID = 1, Name = "Day0StarterSugarFree", Description ="Day0StarterSugarFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Sunday, Image = ""},
                new Meal { MealID = 2, Name = "Day0MainGlutenFree", Description = "Day0MainGlutenFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Sunday, Image = ""},
                new Meal { MealID = 3, Name = "Day0DessertSaltFree", Description = "Day0DessertSaltFree", Category = "Pasta", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Sunday, Image = ""},
                
                new Meal { MealID = 16, Name = "Day5MainGlutenFree", Description = "Day5MainGlutenFree", Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = false, SugarFree = true, Day = DayOfWeek.Friday, Image = ""},
                new Meal { MealID = 17, Name = "Day5StarterSugarFree", Description = "Day5StarterSugarFree", Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = false, Day = DayOfWeek.Friday, Image = ""},
                new Meal { MealID = 18, Name = "Day5DessertSaltFree", Description = "Day5DessertSaltFree", Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = false, SugarFree = false, Day = DayOfWeek.Friday, Image = ""}
            }.AsQueryable<Meal>());

            InputMeals InputMeals = new InputMeals();

            foreach(Meal m in mock.Object.Meals)
            {
                InputMeals.AddItem(m, 1);
            }
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            InputMealsController target = new InputMealsController(mock.Object, InputMeals)
            {
                TempData = tempData
            };

            //Act
            IActionResult result = target.Validate(string.Empty);

            //Assert
            Assert.NotEqual("Checkout", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void ValidateValidMealsForEveryDaySuccess()
        {
            //Arrange

            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            mock.Setup(m => m.Meals).Returns(new Meal[]
            {
                //Sunday
                //Starters
                new Meal { MealID = 1,  Name = "Day0StarterSugarFree", Description = "Day0StarterSugarFree", Category = "Pasta",   Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Sunday,    Image = ""},                                                                                                                                                                                             
                new Meal { MealID = 2,  Name = "Day0MainGlutenFree",   Description = "Day0MainGlutenFree",   Category = "Pasta",   Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Sunday,    Image = ""},                                                                                                                                                                                                           
                new Meal { MealID = 3,  Name = "Day0DessertSaltFree",  Description = "Day0DessertSaltFree",  Category = "Pasta",   Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Sunday,    Image = ""},
                                                                                                                                                                                                                                       
                new Meal { MealID = 4,  Name = "Day1StarterSugarFree", Description = "Day1StarterSugarFree", Category = "Potato",  Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Monday,    Image = ""},
                new Meal { MealID = 5,  Name = "Day1MainGlutenFree",   Description = "Day1MainGlutenFree",   Category = "Potato",  Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Monday,    Image = ""},
                new Meal { MealID = 6,  Name = "Day1DessertSaltFree",  Description = "Day1DessertSaltFree",  Category = "Potato",  Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Monday,    Image = ""},
                //Tuesday                                                                                                                                                                                                                         
                new Meal { MealID = 7,  Name = "Day2StarterSugarFree", Description = "Day2StarterSugarFree", Category = "Salad",   Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Tuesday,   Image = ""},
                new Meal { MealID = 8,  Name = "Day2MainGlutenFree",   Description = "Day2MainGlutenFree",   Category = "Salad",   Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Tuesday,   Image = ""},
                new Meal { MealID = 9,  Name = "Day2DessertSaltFree",  Description = "Day2DessertSaltFree",  Category = "Salad",   Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Tuesday,   Image = ""},
                //Wednesday                                                                                                                                                                                                     
                new Meal { MealID = 10, Name = "Day3StarterSugarFree", Description = "Day3StarterSugarFree", Category = "Mexican", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Wednesday, Image = ""},
                new Meal { MealID = 11, Name = "Day3MainGlutenFree",   Description = "Day3MainGlutenFree",   Category = "Mexican", Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Wednesday, Image = ""},
                new Meal { MealID = 12, Name = "Day3DessertSaltFree",  Description = "Day3DessertSaltFree",  Category = "Mexican", Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Wednesday, Image = ""},
                //Thursday                                                                                                                                                                                                       
                new Meal { MealID = 13, Name = "Day4StarterSugarFree", Description = "Day4StarterSugarFree", Category = "Vegan",   Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Thursday,  Image = ""},
                new Meal { MealID = 14, Name = "Day4MainGlutenFree",   Description =  "Day4MainGlutenFree",  Category = "Vegan",   Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Thursday,  Image = ""},
                new Meal { MealID = 15, Name = "Day4DessertSaltFree",  Description = "Day4DessertSaltFree",  Category = "Vegan",   Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Thursday,  Image = ""},
                //Friday                                                                                                                                                                                                         
                new Meal { MealID = 16, Name = "Day5StarterGlutenFree",Description = "Day5StarterGlutenFree",Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Friday,    Image = ""},
                new Meal { MealID = 17, Name = "Day5MainSugarFree",    Description = "Day5MainSugarFree",    Category = "Chinese", Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Friday,    Image = ""},
                new Meal { MealID = 18, Name = "Day5DessertSaltFree",  Description = "Day5DessertSaltFree",  Category = "Chinese", Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Friday,    Image = ""},
                //Saturday                                                                                                                                                                                                                                     
                new Meal { MealID = 19, Name = "Day6StarterGlutenFree",Description = "Day6StrterGlutenFree", Category = "Bonkers", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Saturday,  Image = ""},
                new Meal { MealID = 20, Name = "Day6MainSugarFree",    Description = "Day6MainSugarFree",    Category = "Bonkers", Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Saturday,  Image = ""},
                new Meal { MealID = 21, Name = "Day6DessertSaltFree",  Description = "Day6DessertSaltFree",  Category = "Bonkers", Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Saturday,  Image = ""}
            }.AsQueryable<Meal>());

            InputMeals InputMeals = new InputMeals();

            foreach (Meal m in mock.Object.Meals)
            {
                InputMeals.AddItem(m, 1);
            }

            InputMealsController target = new InputMealsController(mock.Object, InputMeals);

            //Act
            IActionResult result = target.Validate(string.Empty);

            //Assert
            Assert.Equal("Checkout", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void ValidateValidMealsForEveryDayFail()
        {
            //Arrange

            Mock<IMealRepository> mock = new Mock<IMealRepository>();
            mock.Setup(m => m.Meals).Returns(new Meal[]
            {
                //Sunday
                
                new Meal { MealID = 1,  Name = "Day0StarterSugarFree", Description = "Day0StarterSugarFree", Category = "Pasta",   Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Sunday,    Image = ""},
                new Meal { MealID = 2,  Name = "Day0MainGlutenFree",   Description = "Day0MainGlutenFree",   Category = "Pasta",   Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Sunday,    Image = ""},
                new Meal { MealID = 3,  Name = "Day0DessertSaltFree",  Description = "Day0DessertSaltFree",  Category = "Pasta",   Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Sunday,    Image = ""},
                //Monday
                new Meal { MealID = 4,  Name = "Day1StarterSugarFree", Description = "Day1StarterSugarFree", Category = "Potato",  Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Monday,    Image = ""},
                new Meal { MealID = 5,  Name = "Day1MainGlutenFree",   Description = "Day1MainGlutenFree",   Category = "Potato",  Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Monday,    Image = ""},
                new Meal { MealID = 6,  Name = "Day1DessertSaltFree",  Description = "Day1DessertSaltFree",  Category = "Potato",  Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Monday,    Image = ""},
                //Tuesday                                                                                                                                                                                                                         
                new Meal { MealID = 7,  Name = "Day2StarterSugarFree", Description = "Day2StarterSugarFree", Category = "Salad",   Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Tuesday,   Image = ""},
                new Meal { MealID = 8,  Name = "Day2MainGlutenFree",   Description = "Day2MainGlutenFree",   Category = "Salad",   Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Tuesday,   Image = ""},
                new Meal { MealID = 9,  Name = "Day2DessertSaltFree",  Description = "Day2DessertSaltFree",  Category = "Salad",   Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Tuesday,   Image = ""},
                //Wednesday                                                                                                                                                                                                     
                new Meal { MealID = 10, Name = "Day3StarterSugarFree", Description = "Day3StarterSugarFree", Category = "Mexican", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = false, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Wednesday, Image = ""},
                new Meal { MealID = 11, Name = "Day3MainGlutenFree",   Description = "Day3MainGlutenFree",   Category = "Mexican", Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Wednesday, Image = ""},
                new Meal { MealID = 12, Name = "Day3DessertSaltFree",  Description = "Day3DessertSaltFree",  Category = "Mexican", Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Wednesday, Image = ""},
                //Thursday                                                                                                                                                                                                       
                new Meal { MealID = 13, Name = "Day4StarterSugarFree", Description = "Day4StarterSugarFree", Category = "Vegan",   Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Thursday,  Image = ""},
                new Meal { MealID = 14, Name = "Day4MainGlutenFree",   Description =  "Day4MainGlutenFree",  Category = "Vegan",   Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Thursday,  Image = ""},
                new Meal { MealID = 15, Name = "Day4DessertSaltFree",  Description = "Day4DessertSaltFree",  Category = "Vegan",   Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Thursday,  Image = ""},
                //Friday                                                                                                                                                                                                         
                new Meal { MealID = 16, Name = "Day5StarterGlutenFree",Description = "Day5StarterGlutenFree",Category = "Chinese", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Friday,    Image = ""},
                new Meal { MealID = 17, Name = "Day5MainSugarFree",    Description = "Day5MainSugarFree",    Category = "Chinese", Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Friday,    Image = ""},
                new Meal { MealID = 18, Name = "Day5DessertSaltFree",  Description = "Day5DessertSaltFree",  Category = "Chinese", Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Friday,    Image = ""},
                //Saturday                                                                                                                                                                                                                                     
                new Meal { MealID = 19, Name = "Day6StarterGlutenFree",Description = "Day6StrterGlutenFree", Category = "Bonkers", Course = CourseTypes.Starter, Price = 14.99M, SaltFree = true, GlutenFree = true, SugarFree = true, Day = DayOfWeek.Saturday,  Image = ""},
                new Meal { MealID = 20, Name = "Day6MainSugarFree",    Description = "Day6MainSugarFree",    Category = "Bonkers", Course = CourseTypes.Main,    Price = 14.99M, SaltFree = true, GlutenFree = true,  SugarFree = true, Day = DayOfWeek.Saturday,  Image = ""},
                new Meal { MealID = 21, Name = "Day6DessertSaltFree",  Description = "Day6DessertSaltFree",  Category = "Bonkers", Course = CourseTypes.Dessert, Price = 14.99M, SaltFree = true,  GlutenFree = true, SugarFree = true, Day = DayOfWeek.Saturday,  Image = ""}
            }.AsQueryable<Meal>());

            InputMeals InputMeals = new InputMeals();

            foreach (Meal m in mock.Object.Meals)
            {
                InputMeals.AddItem(m, 1);
            }

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            InputMealsController target = new InputMealsController(mock.Object, InputMeals)
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
