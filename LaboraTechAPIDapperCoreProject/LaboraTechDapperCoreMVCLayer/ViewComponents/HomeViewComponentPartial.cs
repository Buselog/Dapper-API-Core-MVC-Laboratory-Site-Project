using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class HomeViewComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public HomeViewComponentPartial()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7102/api/Home/HomeList");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var homeList = JsonConvert.DeserializeObject<List<Home>>(result);

                return View(homeList);
            }
            return View(new List<Home>());
        }
    }

}
