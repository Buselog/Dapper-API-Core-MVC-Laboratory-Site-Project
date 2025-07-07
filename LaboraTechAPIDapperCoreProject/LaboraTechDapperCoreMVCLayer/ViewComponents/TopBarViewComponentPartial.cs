using LaboraTechDapperCoreMVCLayer.Models;
using LaboraTechDapperCoreMVCLayer.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class TopBarViewComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public TopBarViewComponentPartial()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient(); // url formatında veri almak
            var response = await client.GetAsync("https://localhost:7102/api/Address/AddressList");
            var address = JsonConvert.DeserializeObject<Address>(await response.Content.ReadAsStringAsync());

            return View(address);
        }
    }
}
