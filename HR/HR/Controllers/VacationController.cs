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
    public class VacationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Vacation, VacationSummary> repositry;

        public VacationController(
            IMapper mapper,
            IRepositryAllModels<Vacation, VacationSummary> repositry
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
        }


        [HttpGet]
        public async Task<ActionResult<List<VacationSummary>>> GetAllVacation()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetVacation/{id}")]
        public async Task<ActionResult<VacationSummary>> GetVacationId(Guid id)
        {
            var get =await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/VacationAdded")]
        public async Task<ActionResult<Vacation>> AddVacation([FromBody] VacationCreation Vacation)
        {
            var map = mapper.Map<Vacation>(Vacation);

            var request = repositry.Add(map);

            return CreatedAtAction(nameof(GetAllVacation), new { id = request.id }, map);
        }



        [HttpPut("/api/PutsVacation/{id}")]
        public async Task<ActionResult<Vacation>> PutVacation(Guid id, [FromBody] Vacation Vacation)
        {
            await repositry.Put(id, Vacation);
            return NoContent();
        }

        [HttpDelete("Deleted")]
        public async Task<ActionResult<Vacation>> DeleteVacation(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" Vacation Not Found ... ");
            }
            var Vacationdelete = mapper.Map<VacationSummary>(delete);

            return NoContent();
        }


        [HttpPatch("/api/Vacation/Patch")]
        public async Task<ActionResult<Vacation>> UpdateVacation(Guid id, JsonPatchDocument<Vacation> emp)
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
