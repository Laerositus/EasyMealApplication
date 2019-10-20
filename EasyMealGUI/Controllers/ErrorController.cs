using Microsoft.AspNetCore.Mvc;

namespace EasyMealManagementGUI.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}
