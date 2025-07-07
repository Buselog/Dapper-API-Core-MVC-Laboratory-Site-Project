using APIProjectLayer.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjectLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly DapperModel _dapperContext;
        public TestimonialController(DapperModel dapperModel)
        {
            _dapperContext = dapperModel;
        }

        [HttpGet]
        [Route("TestimonialList")]
        public async Task<IEnumerable<Testimonial>> TestimonialList()
        {
            return await _dapperContext.List<Testimonial>("TestimonialList");
        }

        [HttpGet]
        [Route("GetTestimonialById/{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@TestimonialId", id);

           var value =  await _dapperContext.List<Testimonial>("GetTestimonialById", prm);
            return Ok(value.FirstOrDefault());
        }

        [HttpPost]
        [Route("AddNewTestimonial")]
        public async Task<IActionResult> AddNewTestimonial(Testimonial newTestimonial)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@Name", newTestimonial.Name);
            prm.Add("@Profession", newTestimonial.Profession);
            prm.Add("@Description", newTestimonial.Description);
            prm.Add("@Image", newTestimonial.Image);

            await _dapperContext.Operations("AddNewTestimonial", prm);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id, Testimonial updatedTestimonial)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@TestimonialId", updatedTestimonial.TestimonialId);
            prm.Add("@Name", updatedTestimonial.Name);
            prm.Add("@Profession", updatedTestimonial.Profession);
            prm.Add("@Description", updatedTestimonial.Description);
            prm.Add("@Image", updatedTestimonial.Image);


            await _dapperContext.Operations("UpdateTestimonial", prm);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@TestimonialId", id);

            await _dapperContext.Operations("DeleteTestimonial", prm);
            return Ok();
        }

        [HttpGet]
        [Route("TestimonialCount")]
        public async Task<IActionResult> TestimonialCount()
        {
            int count = await _dapperContext.ExecuteScalarIntAsync("TestimonialCount");
            return Ok(count);
        }

    }
}
