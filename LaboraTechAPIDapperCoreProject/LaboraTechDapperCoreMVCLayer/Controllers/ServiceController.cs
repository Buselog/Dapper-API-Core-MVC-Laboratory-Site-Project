using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class ServiceController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Services addNewService)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(addNewService),
                System.Text.Encoding.UTF8, "application/json"
                );

            var response = client.PostAsync("https://localhost:7102/api/Service/AddNewService", content).Result;

            return RedirectToAction("Index", "LaboraTechLayout");
        }

        // $ -> Parametre almak için kullandık.

        [HttpGet]
        public IActionResult Update(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7102/api/Service/GetServiceById/{id}").Result;
            var Service = JsonConvert.DeserializeObject<Services>(response.Content.ReadAsStringAsync().Result);
            return View(Service);
        }

        [HttpPost]
        public IActionResult Update(Services updatedService)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(updatedService),
                System.Text.Encoding.UTF8, "application/json"
                );

            var response = client.PutAsync($"https://localhost:7102/api/Service/UpdateService/{updatedService.ServicesId}", content).Result;

            return RedirectToAction("Index", "LaboraTechLayout");
        }
      
        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7102/api/Service/DeleteService/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                return Content($"Silme başarısız: {response.StatusCode} - {error}");
            }

            return RedirectToAction("Index", "LaboraTechLayout");
        }
    }
}
