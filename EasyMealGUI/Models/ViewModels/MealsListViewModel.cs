using System.Collections.Generic;

using EasyMealCore.DomainModel;

namespace EasyMealManagementGUI.Models.ViewModels
{
    public class MealsListViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
