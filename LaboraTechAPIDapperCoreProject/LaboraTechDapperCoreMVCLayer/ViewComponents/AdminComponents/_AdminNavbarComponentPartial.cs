using Microsoft.AspNetCore.Mvc;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents.AdminComponents
{
    public class _AdminNavbarComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
