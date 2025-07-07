using Microsoft.AspNetCore.Mvc;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class LaboraTechLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
