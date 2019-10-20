using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

using EasyMealCore.DomainModel;
using EasyMealCore.DomainServices;

namespace EasyMealOrderGUI.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private IOrderRepository repository;

        public InvoiceController(IOrderRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Orders.Where(p => p.UserName == User.Identity.Name));
    }
}
