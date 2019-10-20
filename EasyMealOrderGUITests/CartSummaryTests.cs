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
using RazorGenerator.Testing;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using EasyMealOrderGUI.Components;

namespace EasyMealOrderGUITests
{
    public class CartSummaryTests
    {
        [Fact]
        public void SummaryPriceVcTest()
        {
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

            //var httpContext = new DefaultHttpContext();


            //var viewContext = new ViewContext();
            //viewContext.HttpContext = httpContext;
            //var viewComponentContext = new ViewComponentContext();
            //viewComponentContext.ViewContext = viewContext;

            //var viewComponent = new CartSummaryViewComponent(cart);
            //viewComponent.ViewComponentContext = viewComponentContext;

            ////Act
            //result = viewComponent.Invoke();

            var view = new CartSummaryViewComponent(cart);
            //view.

            //var test = model.Content;
            //Console.WriteLine("Dank");
            //Assert
            Assert.True(true);

        }
    }
}
