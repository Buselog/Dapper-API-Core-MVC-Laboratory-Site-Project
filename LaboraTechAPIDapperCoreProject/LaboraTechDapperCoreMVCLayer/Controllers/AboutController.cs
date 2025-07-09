using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class AboutController : Controller
    {

        [HttpGet]
        public IActionResult Update(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7102/api/About/GetAboutById/{id}").Result;
            var About = JsonConvert.DeserializeObject<About>(response.Content.ReadAsStringAsync().Result);
            return View(About);
        }

        [HttpPost]
        public IActionResult Update(About updatedAbout)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(updatedAbout),
                System.Text.Encoding.UTF8, "application/json"
                );

            var response = client.PutAsync($"https://localhost:7102/api/About/UpdateAbout/{updatedAbout.AboutId}", content).Result;

            return RedirectToAction("Index", "LaboraTechLayout");
        }


        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7102/api/About/DeleteAbout/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                return Content($"Silme başarısız: {response.StatusCode} - {error}");
            }

            return RedirectToAction("Index", "LaboraTechLayout");
        }
    }
}
