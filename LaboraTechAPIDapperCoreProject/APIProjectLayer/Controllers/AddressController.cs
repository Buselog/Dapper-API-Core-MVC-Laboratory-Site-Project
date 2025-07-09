using APIProjectLayer.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace APIProjectLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DapperModel _dapperContext;

        public AddressController(DapperModel dapperModel)
        {
            _dapperContext = dapperModel;
        }

        [HttpGet]
        [Route("AddressList")]
        public async Task<IActionResult> AddressList()
        {
            var firstField = await _dapperContext.List<Address>("AddressList");
            var value = firstField.FirstOrDefault();
            return Ok(value);
        }

        [HttpGet]
        [Route("GetAddressById/{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@AddressId", id);

            var values = await _dapperContext.List<Address>("GetAddressById", prm);
            var firstField = values.FirstOrDefault();
            return Ok(firstField);
        }

        [HttpPut]
        [Route("UpdateAddress/{id}")]
        public async Task<IActionResult> UpdateAddress(int id, Address updatedAddress)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@AddressId", id);
            prm.Add("@SiteTitle", updatedAddress.SiteTitle);
            prm.Add("@Mail", updatedAddress.Mail);
            prm.Add("@Phone", updatedAddress.Phone);
            prm.Add("@Location", updatedAddress.Location);

            await _dapperContext.Operations("UpdateAddress", prm);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@AddressId", id);

            await _dapperContext.Operations("DeleteAddress", prm);
            return Ok();

        }
        
      
    }
}
