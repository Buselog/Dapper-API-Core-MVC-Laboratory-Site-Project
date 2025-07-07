using Microsoft.AspNetCore.Mvc;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class NavbarViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
