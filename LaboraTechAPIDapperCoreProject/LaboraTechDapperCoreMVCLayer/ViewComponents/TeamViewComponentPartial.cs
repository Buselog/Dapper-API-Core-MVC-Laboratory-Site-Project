using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class TeamViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient(); // url formatında veri almak
            var response = await client.GetAsync("https://localhost:7102/api/Team/TeamList");
            List<Team> teamList = JsonConvert.DeserializeObject<List<Team>>(await response.Content.ReadAsStringAsync());
            return View(teamList);
        }
    }
}
