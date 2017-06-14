using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unit;

        public OrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Orders.GetAll());
        }
    }
}