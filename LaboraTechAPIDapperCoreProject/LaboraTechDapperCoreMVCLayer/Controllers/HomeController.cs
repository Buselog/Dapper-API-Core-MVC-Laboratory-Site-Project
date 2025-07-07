using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    HttpClient client = new HttpClient(); // url formatında veri almak
        //    var response = client.GetAsync("https://localhost:7102/api/Home/HomeList").Result;
        //    List<Home> home =
        //        JsonConvert.DeserializeObject<List<Home>>(response.Content.ReadAsStringAsync().Result);

        //    return View(home);
        //}

        [HttpGet]
        public IActionResult Update(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7102/api/Home/GeteHomeById/{id}").Result;
            var home = JsonConvert.DeserializeObject<Home>(response.Content.ReadAsStringAsync().Result);
            return View(home);
        }

        [HttpPost]
        public IActionResult Update(Home updatedHome)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(updatedHome),
                System.Text.Encoding.UTF8, "application/json"
                );

            var response = client.PutAsync($"https://localhost:7102/api/Home/UpdateHome/{updatedHome.HomeId}", content).Result;

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7102/api/Home/DeleteHome/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                return Content($"Silme başarısız: {response.StatusCode} - {error}");
            }

            return RedirectToAction("Index", "LaboraTechLayout");
        }


    }
}
