using AutoMapper;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniverCityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<UniverCity, UniverCitySummary> repositry;

        public UniverCityController(
            IMapper mapper,
            IRepositryAllModels<UniverCity, UniverCitySummary> repositry
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
        }


        [HttpGet]
        public async Task<ActionResult<List<UniverCitySummary>>> GetAllUniverCity()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetUniverCity/{id}")]
        public async Task<ActionResult<UniverCitySummary>> GetUniverCityId(Guid id)
        {
            var get = await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/UniverCityAdded")]
        public async Task<ActionResult<UniverCity>> AddUniverCity([FromBody] UniverCityCreation univercity)
        {
            var map = mapper.Map<UniverCity>(univercity);

            var request = repositry.Add(map);

            return CreatedAtAction(nameof(GetAllUniverCity), new { id = request.id }, map);
        }



        [HttpPut("/api/PutsUniverCity/{id}")]
        public async Task<ActionResult<UniverCity>> PutUniverCity(Guid id, [FromBody] UniverCity univercity)
        {
           await repositry.Put(id, univercity);
            return NoContent();
        }

        [HttpDelete("Deleted")]
        public async Task<ActionResult<UniverCity>> Deleteunivercity(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" UniverCity Not Found ... ");
            }
            var univercitydelete = mapper.Map<UniverCitySummary>(delete);

            return NoContent();
        }




        [HttpPatch("/api/UniverCity/Patch")]
        public async Task<ActionResult<UniverCity>> UpdateUniverCity(Guid id, JsonPatchDocument<UniverCity> emp)
        {
            var patches = repositry.UpdateAsync(id, emp);
            if (patches == null)
            {
                return NotFound();
            }
            return Ok(patches);
        }















    }
}
