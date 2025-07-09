using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.Controllers
{
    public class AddressController : Controller
    {

        [HttpGet]
        public IActionResult Update(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:7102/api/Address/GetAddressById/{id}").Result;
            var Address = JsonConvert.DeserializeObject<Address>(response.Content.ReadAsStringAsync().Result);
            return View(Address);
        }

        [HttpPost]
        public IActionResult Update(Address updatedAddress)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(updatedAddress),
                System.Text.Encoding.UTF8, "application/json"
                );

            var response = client.PutAsync($"https://localhost:7102/api/Address/UpdateAddress/{updatedAddress.AddressId}", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                return Content($"Güncelleme başarısız: {response.StatusCode} - {error}");
            }

            return RedirectToAction("Index", "LaboraTechLayout");
        }


        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:7102/api/Address/DeleteAddress/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                return Content($"Silme başarısız: {response.StatusCode} - {error}");
            }

            return RedirectToAction("Index", "LaboraTechLayout");
        }
    }
}
