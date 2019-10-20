using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

using EasyMealCore.DomainModel;
using EasyMealManagementGUI.Infrastructure;

namespace EasyMealManagementGUI.Models
{
    public class SessionInputMeals : InputMeals
    {
        public static InputMeals GetInputMeals(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionInputMeals InputMeals = session?.GetJson<SessionInputMeals>("InputMeals")
                ?? new SessionInputMeals();
            InputMeals.Session = session;
            return InputMeals;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Meal meal, int quantity)
        {
            base.AddItem(meal, quantity);
            Session.SetJson("InputMeals", this);
        }

        public override void RemoveLine(Meal meal)
        {
            base.RemoveLine(meal);
            Session.SetJson("InputMeals", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("InputMeals");
        }
    }
}
