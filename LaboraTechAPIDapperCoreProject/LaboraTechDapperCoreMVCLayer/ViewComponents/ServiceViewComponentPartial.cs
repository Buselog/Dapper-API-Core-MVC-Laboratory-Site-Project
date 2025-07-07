using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class ServiceViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient(); // url formatında veri almak
            var response = await client.GetAsync("https://localhost:7102/api/Service/ServiceList");
            List<Services> serviceList = JsonConvert.DeserializeObject<List<Services>>(await response.Content.ReadAsStringAsync());
            return View(serviceList);
        }
    }
}
