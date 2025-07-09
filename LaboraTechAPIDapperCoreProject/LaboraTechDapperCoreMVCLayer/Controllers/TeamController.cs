using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class TeamController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7102/api/";

        [HttpGet]
        public IActionResult Add()
        {
            HttpClient client = new HttpClient();

            //Service List for Dropdown
            var response = client.GetAsync($"{apiBaseUrl}Service/ServiceList").Result;
            var serviceList = JsonConvert.DeserializeObject<List<Services>>(response.Content.ReadAsStringAsync().Result);

            ViewBag.ServiceList = serviceList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Team team)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(team), Encoding.UTF8, "application/json");

            var response = client.PostAsync($"{apiBaseUrl}Team/AddNewTeam", content).Result;

            return RedirectToAction("Index", "LaboraTechLayout");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            HttpClient client = new HttpClient();

            // Team bilgisi
            var teamResponse = client.GetAsync($"{apiBaseUrl}Team/GetTeamById/{id}").Result;
            var team = JsonConvert.DeserializeObject<Team>(teamResponse.Content.ReadAsStringAsync().Result);

            // Servis listesi
            var serviceResponse = client.GetAsync($"{apiBaseUrl}Service/ServiceList").Result;
            List<Services> serviceList = JsonConvert.DeserializeObject<List<Services>>(serviceResponse.Content.ReadAsStringAsync().Result);

            ViewBag.ServiceList = serviceList;

            return View(team);
        }

        [HttpPost]
        public IActionResult Update(Team updatedTeam)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(updatedTeam), Encoding.UTF8, "application/json");

            var response = client.PutAsync($"{apiBaseUrl}Team/UpdateTeam/{updatedTeam.TeamId}", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                return Content($"Guncelleme başarısız: {response.StatusCode} - {error}");
            }

            return RedirectToAction("Index", "LaboraTechLayout");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"{apiBaseUrl}Team/DeleteTeam/{id}").Result;

            return RedirectToAction("Index",  "LaboraTechLayout");
        }
    }
}
