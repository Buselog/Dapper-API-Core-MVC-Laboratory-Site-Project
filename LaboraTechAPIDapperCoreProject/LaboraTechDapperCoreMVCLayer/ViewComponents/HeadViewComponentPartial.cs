using Microsoft.AspNetCore.Mvc;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class HeadViewComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
