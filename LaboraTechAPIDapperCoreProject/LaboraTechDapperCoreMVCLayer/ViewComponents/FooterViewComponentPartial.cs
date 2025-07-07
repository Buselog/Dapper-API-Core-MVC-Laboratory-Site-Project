using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class FooterViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient(); // url formatında veri almak
            var response = await client.GetAsync("https://localhost:7102/api/Address/AddressList");
            var addressList = JsonConvert.DeserializeObject<Address>(await response.Content.ReadAsStringAsync());
            return View(addressList);

        }
    }
}
