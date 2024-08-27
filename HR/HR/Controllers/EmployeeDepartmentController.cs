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
    public class EmployeeDepartmentController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IRepositryAllModels<EmployeeDepartment, EmployeeDepartmentSummary> repositry;

        public EmployeeDepartmentController(
            IMapper mapper,
            IRepositryAllModels<EmployeeDepartment, EmployeeDepartmentSummary> repositry
            )
        {
            this.mapper = mapper;
            this.repositry = repositry;
        }




        [HttpGet]
        public async Task<ActionResult<List<EmployeeDepartmentSummary>>> GetAll()
        {
            var gets =await repositry.GetAll();
            //var emp = mapper.Map<List<EmployeeSummary>>(gets);
            return Ok(gets);

        }

        [HttpGet("GetEmployeeDepartment/{id}")]
        public async Task<ActionResult<EmployeeDepartmentSummary>> GetBYId(Guid id)
        {
            var get =await repositry.GetById(id);
            return Ok(get);
        }



        [HttpPost("/api/EmployeeDepartmentAdded")]
        public async Task<ActionResult<EmployeeDepartment>> AddUniverCity([FromBody] EmployeeDepartmentCreation EmployeeDepartment)
        {
            var map = mapper.Map<EmployeeDepartment>(EmployeeDepartment);

            var request = repositry.Add(map);

            repositry.GetById(map.EmployeeId);




            return CreatedAtAction(nameof(GetAll), new { id = request.id }, map);
        }






        [HttpPut("/api/PutsEmployeeDepartment/{id}")]
        public async Task<ActionResult<EmployeeDepartment>> PutUniverCity(Guid id, [FromBody] EmployeeDepartment EmployeeDepartment)
        {
            await repositry.Put(id, EmployeeDepartment);
            return NoContent();
        }



        [HttpDelete("Deleted")]
        public async Task<ActionResult<EmployeeDepartment>> DeleteEmployeeDepartment(Guid id)
        {
            var delete = repositry.Delete(id);

            if (delete is null)
            {
                return BadRequest(" EmployeeDepartment Not Found ... ");
            }
            var EmployeeDepartment = mapper.Map<EmployeeDepartmentSummary>(delete);

            return NoContent();
        }




        [HttpPatch("/api/EmployeeDepartment/Patch")]
        public async Task<ActionResult<EmployeeDepartment>> UpdateEmployeeDepartment(Guid id, JsonPatchDocument<EmployeeDepartment> emp)
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
