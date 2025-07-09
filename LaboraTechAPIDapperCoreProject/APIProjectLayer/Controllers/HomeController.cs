using APIProjectLayer.Models;
using Dapper;
using LaboraTechDapperCoreMVCLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly DapperModel _dapperContext;

        public HomeController(DapperModel dapperModel)
        {
            _dapperContext = dapperModel;
        }

        [HttpGet]
        [Route("HomeList")]
        public async Task<IEnumerable<Home>> HomeList()
        {
            return await _dapperContext.List<Home>("HomeList");
        }

        [HttpGet]
        [Route("GetHomeById/{id}")]
        public async Task<IActionResult> GetHomeById(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@HomeId", id);

            var values = await _dapperContext.List<Home>("GetHomeById", prm);
            var firstField = values.FirstOrDefault();
            return Ok(firstField);
        }


        [HttpPut]
        [Route("UpdateHome/{id}")]
        public async Task<IActionResult> UpdateHome(int id, Home updatedHome)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@HomeId", id);
            prm.Add("@SiteTitle", updatedHome.SiteTitle);
            prm.Add("@Title", updatedHome.Title);
            prm.Add("@SubTitle", updatedHome.SubTitle);
            prm.Add("@ImageUrl", updatedHome.ImageUrl);
            await _dapperContext.Operations("UpdateHome", prm);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteHome/{id}")]

        public async Task<IActionResult> DeleteHome(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@HomeId", id);

            await _dapperContext.Operations("DeleteHome", prm);
            return Ok();
        }

    }
}
