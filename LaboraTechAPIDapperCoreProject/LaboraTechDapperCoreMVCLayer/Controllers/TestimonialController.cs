using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LaboraTechDapperCoreMVCLayer.Models;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class TestimonialController : Controller
    {
        //ViewComponent, sadece yapıyı gösterir, view component class'ı içinde işlem yapılmaz(add, update, delete vs)
        // View componnet içine listeleme fonksiyonu yazılabilir ama diğer işlemler controller'da yazılmalı. 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Testimonial addNewTestimonial)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(addNewTestimonial),
                System.Text.Encoding.UTF8, "application/json"
                );

            var response = client.PostAsync("https://localhost:7102/api/Testimonial/AddNewTestimonial", content).Result;

            return RedirectToAction("Index", "LaboraTechLayout");
        }

        // $ -> Parametre almak için kullandık.

        [HttpGet]
        public IActionResult Update(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7102/api/Testimonial/GetTestimonialById/{id}").Result;
            var Testimonial = JsonConvert.DeserializeObject<Testimonial>(response.Content.ReadAsStringAsync().Result);
            return View(Testimonial);
        }

        [HttpPost]
        public IActionResult Update(Testimonial updatedTestimonial)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(updatedTestimonial),
                System.Text.Encoding.UTF8, "application/json"
                );

            var response = client.PutAsync($"https://localhost:7102/api/Testimonial/UpdateTestimonial/{updatedTestimonial.TestimonialId}", content).Result;

            return RedirectToAction("Index", "LaboraTechLayout");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7102/api/Testimonial/DeleteTestimonial/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                return Content($"Silme başarısız: {response.StatusCode} - {error}");
            }

            return RedirectToAction("Index", "LaboraTechLayout");
        }
    }
}
