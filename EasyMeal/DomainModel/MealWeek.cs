using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace EasyMealCore.DomainModel
{
    public class MealWeek
    {
        [BindNever]
        public int MealWeekID { get; set; }

        [Required(ErrorMessage = "Please enter a weeknumber")]
        [Range(1, 52,
        ErrorMessage = "Please enter a valid weeknumber")]
        public int WeekNumber { get; set; }

        [BindNever]
        public ICollection<InputMealsLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
    }
}
