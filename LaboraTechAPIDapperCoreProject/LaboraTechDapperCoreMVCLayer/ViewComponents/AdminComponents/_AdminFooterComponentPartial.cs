using Microsoft.AspNetCore.Mvc;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents.AdminComponents
{
    public class _AdminFooterComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
