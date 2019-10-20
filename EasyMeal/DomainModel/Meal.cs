using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMealCore.DomainModel.Enums;

namespace EasyMealCore.DomainModel
{
    public class Meal
    {
        public int MealID { get; set; }

        [Required(ErrorMessage = "Please enter a meal name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please specify a course")]
        public CourseTypes Course { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
        ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public bool SaltFree { get; set; }
        public bool SugarFree { get; set; }
        public bool GlutenFree { get; set; }

        [Required(ErrorMessage = "Please enter a day")]
        public DayOfWeek Day { get; set; }
        [Required(ErrorMessage = "Please enter an URL to an image")]
        public string Image { get; set; }
        //[Required(ErrorMessage = "Please provide ingredients")]
        //public string[] Ingredients { get; set; }
    }
}
