using AutoMapper;
using HR.Repositry.Serves;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using HR_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltiesController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Penalties, PenaltiesSummary> repositry;
        private readonly IRepoPenalties repoPenalties;

        public PenaltiesController(
            IMapper mapper,
            IRepositryAllModels<Penalties, PenaltiesSummary> repositry,
            IRepoPenalties repoPenalties
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
            this.repoPenalties = repoPenalties;
        }


        [HttpGet]
        public async Task<ActionResult<List<PenaltiesSummary>>> GetAllPenalties()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetPenalties/{id}")]
        public async Task<ActionResult<PenaltiesSummary>> GetPenaltiesId(Guid id)
        {
            var get = await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/PenaltiesAdded")]
        public async Task<ActionResult<Penalties>> AddPenalties([FromForm] PenaltiesCreation Penalties)
        {
            //var map = mapper.Map<Penalties>(Penalties);

            var request = repoPenalties.AddPenalties(Penalties);

            return CreatedAtAction(nameof(GetAllPenalties), new { id = request.Id }, Penalties);
        }



        [HttpPut("/api/PutsPenalties/{id}")]
        public async Task<ActionResult<Penalties>> PutPenalties(Guid id, [FromBody] Penalties Penalties)
        {
            await repositry.Put(id, Penalties);
            return NoContent();
        }

        [HttpDelete("Deleted")]
        public async Task<ActionResult<Penalties>> DeletePenalties(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Penalties Not Found ... ");
            }
            var Penaltiesdelete = mapper.Map<PenaltiesSummary>(delete);

            return NoContent();
        }


        [HttpPatch("/api/Penalties/Patch")]
        public async Task<ActionResult<Penalties>> UpdatePenalties(Guid id, JsonPatchDocument<Penalties> emp)
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
