using APIProjectLayer.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjectLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly DapperModel _dapperContext;
        public ServiceController(DapperModel dapperModel)
        {
            _dapperContext = dapperModel;
        }

        [HttpGet]
        [Route("ServiceList")]
        public async Task<IEnumerable<Services>> ServiceList()
        {
            return await _dapperContext.List<Services>("ServiceList");
        }

        [HttpGet]
        [Route("GetServiceById/{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@ServicesId", id);

            var values = await _dapperContext.List<Services>("GetServiceById", prm);
            var firstField = values.FirstOrDefault();
            return Ok(firstField);
        }

        [HttpPost]
        [Route("AddNewService")]
        public async Task<IActionResult> AddNewService(Services newService)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@Title", newService.Title);
            prm.Add("@ShortDescription", newService.ShortDescription);
            prm.Add("@Icon", newService.Icon);

            await _dapperContext.Operations("AddNewService", prm);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id, Services updatedService)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@ServicesId", updatedService.ServicesId);
            prm.Add("@Title", updatedService.Title);
            prm.Add("@ShortDescription", updatedService.ShortDescription);
            prm.Add("@Icon", updatedService.Icon);

            await _dapperContext.Operations("UpdateService", prm);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteService/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@ServicesId", id);

            await _dapperContext.Operations("DeleteService", prm);
            return Ok();
        }

        [HttpGet]
        [Route("ServiceCount")]
        public async Task<IActionResult> ServiceCount()
        {
            int count = await _dapperContext.ExecuteScalarIntAsync("ServiceCount");
            return Ok(count);
        }
    }
}
