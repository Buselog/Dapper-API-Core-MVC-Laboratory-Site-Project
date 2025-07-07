using Microsoft.AspNetCore.Mvc;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class ScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
