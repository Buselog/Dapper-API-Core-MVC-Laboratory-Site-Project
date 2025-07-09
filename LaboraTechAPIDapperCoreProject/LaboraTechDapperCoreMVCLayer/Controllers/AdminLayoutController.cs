using Microsoft.AspNetCore.Mvc;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
