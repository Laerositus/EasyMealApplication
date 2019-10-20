using System.Collections.Generic;

using EasyMealCore.DomainModel;

namespace EasyMealOrderGUI.Models.ViewModels
{
    public class MealsListViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
