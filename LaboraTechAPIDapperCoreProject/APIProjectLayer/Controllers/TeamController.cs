using APIProjectLayer.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjectLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    /*
     Eğer sadece "işlem başarılı" demek istiyorsan ve veri döndürmeyeceksen (POST, DELETE sonrası gibi), Ok(); kullanılabilir.

     Ama GET işlemlerinde her zaman Ok(veri) kullanılır.
     */


    public class TeamController : ControllerBase
    {
        private readonly DapperModel _dapperContext;
        public TeamController(DapperModel dapperModel)
        {
            _dapperContext = dapperModel;
        }

        [HttpGet]
        [Route("TeamList")]
        public async Task<IActionResult> TeamList()
        {
            var result = await _dapperContext.MultiMap<Team, Services>(
             "TeamList",
             (team, service) =>
             {
               team.Services = service;
               return team;
             },
              splitOn: "ServicesId"
             );

            return Ok(result);
        }

        [HttpGet]
        [Route("GetTeamById/{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@TeamId", id);

            var result = await _dapperContext.MultiMap<Team, Services>(
            "GetTeamById",
            (team, service) =>
            {
                team.Services = service;
                return team;
            },
             splitOn: "ServicesId",
             prm
            );

            var firstField = result.FirstOrDefault();

            return Ok(firstField);
        }

        [HttpPost]
        [Route("AddNewTeam")]
        public async Task<IActionResult> AddNewTeam(UpdateTeamDto newTeam)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@Name", newTeam.Name);
            prm.Add("@Image", newTeam.Image);
            prm.Add("@SocialMedia", newTeam.SocialMedia);
            prm.Add("@ServicesId", newTeam.ServicesId);

            await _dapperContext.Operations("AddTeam", prm);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateTeam/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, UpdateTeamDto updatedTeam)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@TeamId", id);
            prm.Add("@Name", updatedTeam.Name);
            prm.Add("@Image", updatedTeam.Image);
            prm.Add("@SocialMedia", updatedTeam.SocialMedia);
            prm.Add("@ServicesId", updatedTeam.ServicesId);


            await _dapperContext.Operations("UpdateTeam", prm);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteTeam/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@TeamId", id);

            await _dapperContext.Operations("DeleteTeam", prm);
            return Ok();
        }

        [HttpGet]
        [Route("TeamCount")]
        public async Task<IActionResult> TeamCount()
        {
            int count = await _dapperContext.ExecuteScalarIntAsync("TeamCount");
            return Ok(count);
        }
    }
}
