using APIProjectLayer.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjectLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {

        private readonly DapperModel _dapperContext;

        public AboutController(DapperModel dapperModel)
        {
            _dapperContext = dapperModel;
        }

        [HttpGet]
        [Route("AboutList")]
        public async Task<IActionResult> AboutList()
        {
            var firsField = await _dapperContext.List<About>("AboutList");
            var value = firsField.FirstOrDefault();
            return Ok(value);

        }


        [HttpGet]
        [Route("GetAboutById/{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@AboutId", id);

            var values = await _dapperContext.List<About>("GetAboutById", prm);
            var firstField = values.FirstOrDefault();
            return Ok(firstField);
        }

        [HttpPut]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id, About updatedAbout)
        {
            if (updatedAbout == null)
                return BadRequest("UpdatedAbout cannot be null.");

            DynamicParameters prm = new DynamicParameters();
            prm.Add("@AboutId", id);  // URL'den gelen id kullanılıyor
            prm.Add("@Title", updatedAbout.Title);
            prm.Add("@ShortDescription", updatedAbout.ShortDescription);
            prm.Add("@ExperienceYear", updatedAbout.ExperienceYear);
            prm.Add("@CompleteCases", updatedAbout.CompleteCases);
            prm.Add("@ImageUrl1", updatedAbout.ImageUrl1);
            prm.Add("@ImageUrl2", updatedAbout.ImageUrl2);
            prm.Add("@ImageUrl3", updatedAbout.ImageUrl3);

            await _dapperContext.Operations("UpdateAbout", prm);
            return Ok();
        }


        [HttpDelete]
        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@AboutId", id);
            await _dapperContext.Operations("DeleteAbout", prm);
            return Ok();
        }

    }
}
