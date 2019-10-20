using Microsoft.AspNetCore.Mvc;

namespace EasyMealOrderGUI.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}
