using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaboraTechDapperCoreMVCLayer.ViewComponents
{
    public class AboutViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient(); // url formatında veri almak
            var response = await client.GetAsync("https://localhost:7102/api/About/AboutList");
            var about = JsonConvert.DeserializeObject<About>(await response.Content.ReadAsStringAsync());

            var responseTeam = await client.GetAsync("https://localhost:7102/api/Team/TeamCount");
            var teamCount = await responseTeam.Content.ReadAsStringAsync();

            var responseTestimonial = await client.GetAsync("https://localhost:7102/api/Testimonial/TestimonialCount");
            var testimonialCount = await responseTestimonial.Content.ReadAsStringAsync();

            ViewBag.TeamCount = teamCount;
            ViewBag.TestimonialCount = testimonialCount;


            //modeli gönderiyoruz:
            return View(about);
        }
    }
}
